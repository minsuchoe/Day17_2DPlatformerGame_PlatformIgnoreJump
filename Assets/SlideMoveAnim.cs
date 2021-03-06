﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMoveAnim : MonoBehaviour {
        public float pathLength = 5f;
        public float speed = 3f;

        Vector3 start, end, cur;

        void Start()
        {
            start = transform.position;
            end = transform.position + Vector3.right * pathLength;
            cur = end;
        }

        void Update()
        {
            float dist = Vector3.Distance(transform.position, cur);
            if (dist > 0.05f)
                transform.position = Vector3.Lerp(transform.position, cur, speed * Time.deltaTime / dist);
            else
                cur = cur == start ? end : start;   //앞이 true, 뒤가 false.

            //transform.Rotate(Vector3.up * 100f * Time.deltaTime);
        }
    }
