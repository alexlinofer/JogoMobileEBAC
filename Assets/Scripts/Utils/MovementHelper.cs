using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;

    public float maxDuration = 3f;
    private float _currentDuration;

    private int _index = 0;

    private void Start()
    {
        _index = Random.Range(0, positions.Count);
        transform.position = positions[_index].transform.position;
        NextIndex();
        StartCoroutine(StartMovement());
        _currentDuration = Random.Range(1, maxDuration);
    }

    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }


    IEnumerator StartMovement()
    {
        float time = 0;

        while (true)
        {
            var currentPosition = transform.position;

            while(time < _currentDuration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, time/_currentDuration);

                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();

            time = 0;

            yield return null;
        }
    }

}
