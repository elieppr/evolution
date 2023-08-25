using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // Settings variables
    // GENERAL
    public Camera mainCamera;
    public Material objectMaterial;
    public MeshRenderer objectRenderer;
    public GameObject objectMat;
    public Slider backgroundRSlider;
    public Slider backgroundGSlider;
    public Slider backgroundBSlider;
    public Slider wallRSlider;
    public Slider wallGSlider;
    public Slider wallBSlider;

    public float backgroundR;
    public float backgroundG;
    public float backgroundB;
    public TMP_Text BackR;
    public TMP_Text BackG;
    public TMP_Text BackB;
    public float wallR;
    public float wallG;
    public float wallB;
    public TMP_Text WallR;
    public TMP_Text WallG;
    public TMP_Text WallB;


    public Color backgroundColor;
    public Color wallMaterialColor;
    public int maxP;
    public int maxF = 20;
    public int maxFF = 300;
    public Slider maxPengiunSlider;
    public Slider maxFishSlider;
    public Slider maxFishFoodSlider;
    public TMP_Text maxPenguin;
    public TMP_Text maxFish;
    public TMP_Text maxFishFood;
    public int minP;
    public int minF = 20;
    public int minFF = 300;
    public Slider minPengiunSlider;
    public Slider minFishSlider;
    public Slider minFishFoodSlider;
    public TMP_Text minPenguin;
    public TMP_Text minFish;
    public TMP_Text minFishFood;
    public int spawnFF;
    public Slider spawnFishFoodSlider;
    public TMP_Text spawnFishFood;

    // PENGUIN
    public float maxSpeedP = 12;
    public float maxRotationSpeedP = 10;
    public float viewDistanceP = 100;
    public float minSizeP = 60;
    public float maxSizeP = 80;
    public float maxEnergyP = 150;
    public float startingEnergyP = 10;
    public float energyGainedP = 1.5f;
    public float reproductionEnergyGainedP = 1;
    public float reproductionEnergyThresholdP = 2;
    public int numberOfChildrenP = 1;
    public float maxLifeSpanP = 200;
    public float mutationAmountP = 0.2f;
    public float mutationChanceP = 0.5f;
    public bool leakyReluP = true;
    public bool sigmoidP = false;
    public bool tanhP = false;
    public bool reluP = false;

    public TMP_Text value1P;
    public TMP_Text value2P;
    public TMP_Text value3P;
    public TMP_Text value4P;
    public TMP_Text value5P;
    public TMP_Text value6P;
    public TMP_Text value7P;
    public TMP_Text value8P;
    public TMP_Text value9P;
    public TMP_Text value10P;
    public TMP_Text value11P;
    public TMP_Text value12P;
    public TMP_Text value13P;
    public TMP_Text value14P;

    // FISH
    public float maxSpeedF = 12;
    public float maxRotationSpeedF = 5;
    public float viewDistanceF = 70;
    public float minSizeF = 50;
    public float maxSizeF = 50;
    public float maxEnergyF = 100;
    public float startingEnergyF = 4;
    public float energyGainedF = 1;
    public float reproductionEnergyGainedF = 1;
    public float reproductionEnergyThresholdF = 1;
    public int numberOfChildrenF = 3;
    public float maxLifeSpanF = 150;
    public float mutationAmountF = 0.2f;
    public float mutationChanceF = 0.5f;
    public bool leakyReluF = true;
    public bool sigmoidF = false;
    public bool tanhF = false;
    public bool reluF = false;

    public TMP_Text value1F;
    public TMP_Text value2F;
    public TMP_Text value3F;
    public TMP_Text value4F;
    public TMP_Text value5F;
    public TMP_Text value6F;
    public TMP_Text value7F;
    public TMP_Text value8F;
    public TMP_Text value9F;
    public TMP_Text value10F;
    public TMP_Text value11F;
    public TMP_Text value12F;
    public TMP_Text value13F;
    public TMP_Text value14F;

    // Reference to UI elements
    public Slider maxSpeedSliderP;
    public Slider maxRotationSliderP;
    public Slider viewDistanceSliderP;
    public Slider minSizeSliderP;
    public Slider maxSizeSliderP;
    public Slider maxEnergySliderP;
    public Slider startingEnergySliderP;
    public Slider energyGainedSliderP;
    public Slider reproEnergyGainedSliderP;
    public Slider reproEnergyThreshSliderP;
    public Slider numChildrenSliderP;
    public Slider maxLifeSpanSliderP;
    public Slider mutationAmountSliderP;
    public Slider mutationChanceSliderP;
    public Toggle leakyReluToggleP;
    public Toggle sigmoidToggleP;
    public Toggle tanhToggleP;
    public Toggle reluToggleP;

    public Slider maxSpeedSliderF;
    public Slider maxRotationSliderF;
    public Slider viewDistanceSliderF;
    public Slider minSizeSliderF;
    public Slider maxSizeSliderF;
    public Slider maxEnergySliderF;
    public Slider startingEnergySliderF;
    public Slider energyGainedSliderF;
    public Slider reproEnergyGainedSliderF;
    public Slider reproEnergyThreshSliderF;
    public Slider numChildrenSliderF;
    public Slider maxLifeSpanSliderF;
    public Slider mutationAmountSliderF;
    public Slider mutationChanceSliderF;
    public Toggle leakyReluToggleF;
    public Toggle sigmoidToggleF;
    public Toggle tanhToggleF;
    public Toggle reluToggleF;

    private float originalTimeScale;

    //text.text = $"{newScale.ToString("0.000")}";
    

    private void Start()
    {
        PauseGame();
        // PENGUIN
        UpdateMaxSpeedP();
        UpdateMaxRotationP();
        UpdateViewDistanceP();
        UpdateMinSizeP();
        UpdateMaxSizeP();
        UpdateMaxEnergyP();
        UpdateStartingEnergyP();
        UpdateEnergyGainedP();
        UpdateRepEnergyThreshP();
        UpdateRepEnergyGainedP();
        UpdateNumChildrenP();
        UpdateMaxLifeSpanP();
        UpdateMutationAmountP();
        UpdateMutationChanceP();
        

        // FISH
        UpdateMaxSpeedF();
        UpdateMaxRotationF();
        UpdateViewDistanceF();
        UpdateMinSizeF();
        UpdateMaxSizeF();
        UpdateMaxEnergyF();
        UpdateStartingEnergyF();
        UpdateEnergyGainedF();
        UpdateRepEnergyThreshF();
        UpdateRepEnergyGainedF();
        UpdateNumChildrenF();
        UpdateMaxLifeSpanF();
        UpdateMutationAmountF();
        UpdateMutationChanceF();

        backgroundRSlider.value = 90;
        backgroundGSlider.value = 155;
        backgroundBSlider.value = 255;
        wallRSlider.value = 200;
        wallGSlider.value = 200;
        wallBSlider.value = 200;
        wallMaterialColor = new Color(200, 200, 200);
        UpdateBackgroundColor();
        UpdateMaterialColor();

        UpdateMaxPenguins();
        UpdateMaxFish();
        UpdateMaxFishFood();
        UpdateMinPenguins();
        UpdateMinFish();
        UpdateMinFishFood();
        UpdateStartFishFood();
    }

    public void PauseGame()
    {
        originalTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = originalTimeScale;
    }

    // GENERAL NOT DONE
    public void UpdateMaxPenguins()
    {
        maxP = (int)maxPengiunSlider.value;
        maxPenguin.text = $"{maxP.ToString("0")}";
    }
    public void UpdateMaxFish()
    {
        maxF = (int)maxFishSlider.value;
        maxFish.text = $"{maxF.ToString("0")}";
    }
    public void UpdateMaxFishFood()
    {
        maxFF = (int)maxFishFoodSlider.value;
        maxFishFood.text = $"{maxFF.ToString("0")}";
    }

    public void UpdateMinPenguins()
    {
        minP = (int)minPengiunSlider.value;
        minPenguin.text = $"{minP.ToString("0")}";
    }
    public void UpdateMinFish()
    {
        minF = (int)minFishSlider.value;
        minFish.text = $"{minF.ToString("0")}";
    }
    public void UpdateMinFishFood()
    {
        minFF = (int)minFishFoodSlider.value;
        minFishFood.text = $"{minFF.ToString("0")}";
    }

    public void UpdateStartFishFood()
    {
        spawnFF = (int)spawnFishFoodSlider.value;
        spawnFishFood.text = $"{spawnFF.ToString("0")}";
    }

    // PENGUIN
    public void UpdateMaxSpeedP()
    {
        maxSpeedP = maxSpeedSliderP.value;
        value1P.text = $"{maxSpeedP.ToString("0.0")}";
    }
    public void UpdateMaxRotationP()
    {
        maxRotationSpeedP = maxRotationSliderP.value;
        value2P.text = $"{maxRotationSpeedP.ToString("0.0")}";
    }
    public void UpdateViewDistanceP()
    {
        viewDistanceP = viewDistanceSliderP.value;
        value3P.text = $"{viewDistanceP.ToString("0.0")}";
    }
    public void UpdateMinSizeP()
    {
        minSizeP = minSizeSliderP.value;
        value4P.text = $"{minSizeP.ToString("0.0")}";
    }
    public void UpdateMaxSizeP()
    {
        maxSizeP = maxSizeSliderP.value;
        value5P.text = $"{maxSizeP.ToString("0.0")}";
    }
    public void UpdateMaxEnergyP()
    {
        maxEnergyP = maxEnergySliderP.value;
        value6P.text = $"{maxEnergyP.ToString("0.0")}";
    }
    public void UpdateStartingEnergyP()
    {
        startingEnergyP = startingEnergySliderP.value;
        value7P.text = $"{startingEnergyP.ToString("0.0")}";
    }
    public void UpdateEnergyGainedP()
    {
        energyGainedP = energyGainedSliderP.value;
        value8P.text = $"{energyGainedP.ToString("0.0")}";
    }
    public void UpdateRepEnergyThreshP()
    {
        reproductionEnergyThresholdP = reproEnergyThreshSliderP.value;
        value9P.text = $"{reproductionEnergyThresholdP.ToString("0.0")}";
    }
    public void UpdateRepEnergyGainedP()
    {
        reproductionEnergyGainedP = reproEnergyGainedSliderP.value;
        value10P.text = $"{reproductionEnergyGainedP.ToString("0.0")}";
    }
    public void UpdateNumChildrenP()
    {
        numberOfChildrenP = (int)numChildrenSliderP.value; 
        value11P.text = $"{numberOfChildrenP.ToString("0")}";
    }
    public void UpdateMaxLifeSpanP()
    {
        maxLifeSpanP = maxLifeSpanSliderP.value;
        value12P.text = $"{maxLifeSpanP.ToString("0.0")}";
    }
    public void UpdateMutationAmountP()
    {
        mutationAmountP = mutationAmountSliderP.value;
        value13P.text = $"{mutationAmountP.ToString("0.0")}";
    }
    public void UpdateMutationChanceP()
    {
        mutationChanceP = mutationChanceSliderP.value;
        value14P.text = $"{mutationChanceP.ToString("0.00")}";
    }
    public void ToggleLeakyReluP()
    {
        leakyReluToggleP.Select();
        leakyReluP = !leakyReluP;
        if (leakyReluP)
        {
            sigmoidP = false;
            tanhP = false;
            reluP = false;
        }
    }
    public void ToggleSigmoidP()
    {
        sigmoidToggleP.Select();
        sigmoidP = !sigmoidP;
        if (sigmoidP)
        {
            leakyReluP = false;
            tanhP = false;
            reluP = false;
        }
    }
    public void ToggleTanhP()
    {
        tanhToggleP.Select();
        tanhP = !tanhP;
        if (tanhP)
        {
            leakyReluP = false;
            sigmoidP = false;
            reluP = false;
        }
    }
    public void ToggleReluP()
    {
        reluToggleP.Select();
        reluP = !reluP;
        if (reluP)
        {
            leakyReluP = false;
            sigmoidP = false;
            tanhP = false;
        }
    }

    // FISH
    public void UpdateMaxSpeedF()
    {
        maxSpeedF = maxSpeedSliderF.value;
        value1F.text = $"{maxSpeedF.ToString("0.0")}";
    }
    public void UpdateMaxRotationF()
    {
        maxRotationSpeedF = maxRotationSliderF.value;
        value2F.text = $"{maxRotationSpeedF.ToString("0.0")}";
    }
    public void UpdateViewDistanceF()
    {
        viewDistanceF = viewDistanceSliderF.value;
        value3F.text = $"{viewDistanceF.ToString("0.0")}";
    }
    public void UpdateMinSizeF()
    {
        minSizeF = minSizeSliderF.value;
        value4F.text = $"{minSizeF.ToString("0.0")}";
    }
    public void UpdateMaxSizeF()
    {
        maxSizeF = maxSizeSliderF.value;
        value5F.text = $"{maxSizeF.ToString("0.0")}";
    }
    public void UpdateMaxEnergyF()
    {
        maxEnergyF = maxEnergySliderF.value;
        value6F.text = $"{maxEnergyF.ToString("0.0")}";
    }
    public void UpdateStartingEnergyF()
    {
        startingEnergyF = startingEnergySliderF.value;
        value7F.text = $"{startingEnergyF.ToString("0.0")}";
    }
    public void UpdateEnergyGainedF()
    {
        energyGainedF = energyGainedSliderF.value;
        value8F.text = $"{energyGainedF.ToString("0.0")}";
    }
    public void UpdateRepEnergyThreshF()
    {
        reproductionEnergyThresholdF = reproEnergyThreshSliderF.value;
        value9F.text = $"{reproductionEnergyThresholdF.ToString("0.0")}";
    }
    public void UpdateRepEnergyGainedF()
    {
        reproductionEnergyGainedF = reproEnergyGainedSliderF.value;
        value10F.text = $"{reproductionEnergyGainedF.ToString("0.0")}";
    }
    public void UpdateNumChildrenF()
    {
        numberOfChildrenF = (int)numChildrenSliderF.value;
        value11F.text = $"{numberOfChildrenF.ToString("0")}";
    }
    public void UpdateMaxLifeSpanF()
    {
        maxLifeSpanF = maxLifeSpanSliderF.value;
        value12F.text = $"{maxLifeSpanF.ToString("0.0")}";
    }
    public void UpdateMutationAmountF()
    {
        mutationAmountF = mutationAmountSliderF.value;
        value13F.text = $"{mutationAmountF.ToString("0.0")}";
    }
    public void UpdateMutationChanceF()
    {
        mutationChanceF = mutationChanceSliderF.value;
        value14F.text = $"{mutationChanceF.ToString("0.00")}";
    }
    public void ToggleLeakyReluF()
    {
        leakyReluToggleF.Select();
        leakyReluF = !leakyReluF;
        if (leakyReluF)
        {
            sigmoidF = false;
            tanhF = false;
            reluF = false;
        }
    }
    public void ToggleSigmoidF()
    {
        sigmoidToggleF.Select();
        sigmoidF = !sigmoidF;
        if (sigmoidF)
        {
            leakyReluF = false;
            tanhF = false;
            reluF = false;
        }
    }
    public void ToggleTanhF()
    {
        tanhToggleF.Select();
        tanhF = !tanhF;
        if (tanhF)
        {
            leakyReluF = false;
            sigmoidF = false;
            reluF = false;
        }
    }
    public void ToggleReluF()
    {
        reluToggleF.Select();
        reluF = !reluF;
        if (reluF)
        {
            leakyReluF = false;
            sigmoidF = false;
            tanhF = false;
        }
    }

    public void UpdateBackR()
    {
        backgroundR = backgroundRSlider.value;
        BackR.text = $"{backgroundR.ToString("0.0")}";
        UpdateBackgroundColor();
    }
    public void UpdateBackG()
    {
        backgroundG = backgroundGSlider.value;
        BackG.text = $"{backgroundG.ToString("0.0")}";
        UpdateBackgroundColor();
    }
    public void UpdateBackB()
    {
        backgroundB = backgroundBSlider.value;
        BackB.text = $"{backgroundB.ToString("0.0")}";
        UpdateBackgroundColor();
    }

    public void UpdateWallR()
    {
        wallR = wallRSlider.value;
        WallR.text = $"{wallR.ToString("0.0")}";
        UpdateMaterialColor();
    }
    public void UpdateWallG()
    {
        wallG = wallGSlider.value;
        WallG.text = $"{wallG.ToString("0.0")}";
        UpdateMaterialColor();
    }
    public void UpdateWallB()
    {
        wallB = wallBSlider.value;
        WallB.text = $"{wallB.ToString("0.0")}";
        UpdateMaterialColor();
    }


    public void UpdateBackgroundColor()
    {
        
        mainCamera.backgroundColor = new Color(backgroundR / 255f, backgroundG / 255f, backgroundB / 255f);
        
    }

    public void UpdateMaterialColor()
    {
        wallMaterialColor = new Color(wallR / 255f, wallG / 255f, wallB / 255f);
        
        
    }



    public void SaveSettings()
    {
        // Save settings using PlayerPrefs or another method
    }

    public void LoadSettings()
    {
        // Load settings using PlayerPrefs or another method
    }
}
