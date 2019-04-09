using System.Collections;
using UnityEngine;

public class WaveForm : MonoBehaviour
{
    private const int DataLength = 256;

    public AudioSource soundSource;
    public LineStrip waveLineStrip;

    private float soundVolume;
    private Coroutine stoppingSoundCoroutine;
    private float[] waveData;
    private float waveFormOffsetY;

    // 音量によって波の振幅が変化しているのをアピールするため、停止時にフェードアウトさせるようにしました
    private IEnumerator StopSound(float time)
    {
        while (this.soundSource.volume > 0.0f)
        {
            this.soundSource.volume -= (this.soundVolume * Time.deltaTime) / time;
            yield return null;
        }

        this.soundSource.Stop();
        this.stoppingSoundCoroutine = null;
    }

    private void Start()
    {
        this.soundVolume = this.soundSource.volume;
        this.waveData = new float[DataLength];
        this.waveLineStrip.Positions = new Vector2[DataLength]; // Positionsに新しいVector2配列をセット→DataLength個のコーナーを持つ折れ線になる

        for (var i = 0; i < DataLength; i++)
        {
            this.waveLineStrip.Positions[i].x = i; // 各コーナーのX座標を書き換える
        }

        this.waveLineStrip.SetVerticesDirty(); // Positionsを書き換えたので、メッシュの更新が必要なことを通知する
        this.waveFormOffsetY = this.waveLineStrip.rectTransform.rect.height * 0.5f;
    }

    private void Update()
    {
        // スペースキーで音声の再生・停止を切り替える
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var stopping = this.stoppingSoundCoroutine != null;

            if (this.soundSource.isPlaying && !stopping)
            {
                this.stoppingSoundCoroutine = StartCoroutine(StopSound(5.0f));
            }
            else
            {
                if (stopping)
                {
                    this.StopCoroutine(this.stoppingSoundCoroutine);
                    this.stoppingSoundCoroutine = null;
                }

                this.soundSource.volume = this.soundVolume;
                this.soundSource.Play();
            }
        }

        this.soundSource.GetOutputData(this.waveData, 0); // soundSourceが現在再生している音声データをwaveDataに取り出す

        for (var i = 0; i < DataLength; i++)
        {
            this.waveLineStrip.Positions[i].y =
                this.waveFormOffsetY + (this.waveData[i] * 64.0f); // waveDataの値に応じて各コーナーのY座標を書き換える
        }

        this.waveLineStrip.SetVerticesDirty(); // Positionsを書き換えたので、メッシュの更新が必要なことを通知する
    }
}
