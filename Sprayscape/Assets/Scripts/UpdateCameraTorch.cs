// Copyright 2016 Google Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using UnityEngine;
using UnityEngine.UI;

public class UpdateCameraTorch : MonoBehaviour
{
	public CameraCapture captureController;
	public RawImage image;
	public Texture2D onIcon;
	public Texture2D offIcon;

	void Awake()
	{
		if (captureController == null)
		{
			captureController = FindObjectOfType<CameraCapture>();
		}

		if (image == null)
		{
			image = GetComponent<RawImage>();
		}
	}

	void Start()
	{
		UpdateIcon();
	}

	void OnEnable()
	{
		captureController.FacingChanged += FacingChanged;
		captureController.TorchChanged += TorchChanged;
	}

	void OnDisable()
	{
		captureController.FacingChanged -= FacingChanged;
		captureController.TorchChanged -= TorchChanged;
	}

	private void FacingChanged(CameraFacing facing)
	{
		UpdateIcon();
	}
	
	private void TorchChanged(bool on)
	{
		UpdateIcon();
	}

	private void UpdateIcon()
	{
		image.enabled = captureController.IsTorchSupported;
		image.texture = captureController.IsTorchEnabled ? onIcon : offIcon;
	}
}