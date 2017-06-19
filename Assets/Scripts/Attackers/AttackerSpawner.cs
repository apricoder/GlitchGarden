using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Attackers {
  public class AttackerSpawner : MonoBehaviour {

    public GameObject[] AttackersPrefabs;

    private Dictionary<string, float> _spawnCounts;
    private float _startDelay;
    private float _periodDelay;

    private void Start() {
      _spawnCounts = new Dictionary<string, float>();
      foreach (var attackerPref in AttackersPrefabs) {
        _spawnCounts.Add(attackerPref.name, Random.Range(5.0f, 25.0f));
      }
    }


    public void Spawn(GameObject attacker) {
      attacker.transform.position = Vector3.zero;
      Instantiate(attacker, transform);
      _spawnCounts[attacker.name] = Time.timeSinceLevelLoad;
      _periodDelay = Random.Range(-0.5f, 3.5f);
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
      var time = Time.timeSinceLevelLoad;
      var period = attacker.AppearingEverySeconds + _periodDelay;
      var periodPassed = time - _spawnCounts[attackerGo.name] > period;
      return periodPassed;
    }

  }
}