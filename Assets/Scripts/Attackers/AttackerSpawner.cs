using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Attackers {
  public class AttackerSpawner : MonoBehaviour {

    public GameObject[] AttackersPrefabs;

    private Dictionary<string, int> _spawnCounts;
    private float _randomDelay;

    private void Start() {
      _randomDelay = Random.Range(5.0f, 25.0f);
      _spawnCounts = new Dictionary<string, int>();
      foreach (var attackerPref in AttackersPrefabs) {
        _spawnCounts.Add(attackerPref.name, 0);
      }
    }


    public void Spawn(GameObject attacker) {
      attacker.transform.position = Vector3.zero;
      Instantiate(attacker, transform);
      _spawnCounts[attacker.name] = Mathf.FloorToInt(Time.timeSinceLevelLoad + _randomDelay);
    }

    private void Update() {
      foreach (var attackerGo in AttackersPrefabs) {
        if (TimeToSpawn(attackerGo)) {
          Spawn(attackerGo);
        }
      }
    }

    private bool TimeToSpawn(GameObject attackerGo) {
      var attacker = attackerGo.GetComponent<Attacker>();
      var time = Time.timeSinceLevelLoad + _randomDelay;
      var range = attacker.AppearingEverySeconds * 7;
      range += Random.Range(-0.5f * range, 0.5f * range);
      return time % range < 0.5f && _spawnCounts[attackerGo.name] <= Mathf.FloorToInt(time / range);
    }

  }
}