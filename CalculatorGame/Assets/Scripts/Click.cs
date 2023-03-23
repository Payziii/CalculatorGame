using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public int money;
	private int TwoBuy = 0;
	private int ThreeBuy = 0;
	private int lvl_money;
	private int button_active = -5;
	[SerializeField] private Text TextMoney;
	[SerializeField] private Text TwoPlayButton;
	[SerializeField] private Text ThreePlayButton;
	[SerializeField] private GameObject TwoErrorText;
	[SerializeField] private GameObject ThreeErrorText;
	[SerializeField] private Text OneLvlTextMoney;
	[SerializeField] private Text TwoLvlTextMoney;
	[SerializeField] private Text ThreeLvlTextMoney;
	[SerializeField] private GameObject GlobalMenu;
	[SerializeField] private GameObject OneLevelMenu;
	[SerializeField] private GameObject TwoLevelMenu;
	[SerializeField] private GameObject TwoLevelInfo;
	[SerializeField] private GameObject ThreeLevelMenu;
	[SerializeField] private GameObject ThreeLevelInfo;
	[SerializeField] private GameObject LevelsMenu;
	[SerializeField] private GameObject TwoZamok;
	[SerializeField] private GameObject ThreeZamok;
	
	private void Start()
	{
		if(PlayerPrefs.HasKey("Money"))
		{
			money = PlayerPrefs.GetInt("Money");
		}
		TextMoney.text = "Баланс: "+money.ToString()+" P$";
		
		if(PlayerPrefs.HasKey("TwoBuy"))
		{
			TwoBuy = PlayerPrefs.GetInt("TwoBuy");
		}
		if(TwoBuy == 1)
		{
			TwoPlayButton.text = "Играть";
			TwoZamok.SetActive(false);
		}
		
		if(PlayerPrefs.HasKey("ThreeBuy"))
		{
			ThreeBuy = PlayerPrefs.GetInt("ThreeBuy");
		}
		if(ThreeBuy == 1)
		{
			ThreePlayButton.text = "Играть";
			ThreeZamok.SetActive(false);
		}
	}
	//Подготавливает уровень к началу игры
	public void LvLCheck()
	{
		if(PlayerPrefs.HasKey("lvl_money"))
		{
			lvl_money = 0;
			PlayerPrefs.SetInt("lvl_money", 0);
			OneLvlTextMoney.text = "0";
			TwoLvlTextMoney.text = "0";
			ThreeLvlTextMoney.text = "0";
		}
		button_active = -5;
	}
	//Клик кнопки "1" на первом уровне
	public void OneLvLClickOne()
	{
		if(button_active == 1)
		{
			GlobalMenu.SetActive(true);
			OneLevelMenu.SetActive(false);
			return;
		}
		button_active = 1;
	}
	//Клик кнопки "+" на первом уровне
	public void OneLvLClickPlus()
	{
		if(button_active < 1)
		{
			GlobalMenu.SetActive(true);
			OneLevelMenu.SetActive(false);
			return;
		}
		button_active = 0;
		money++;
		lvl_money++;
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetInt("lvl_money", lvl_money);
		OneLvlTextMoney.text = lvl_money.ToString();
		TextMoney.text = "Баланс: "+money.ToString()+" P$";
	}
	//Покупка второго уровня (или переход на него, если куплен)
	public void BuyTwoLVL()
	{
		if(TwoBuy == 0)
		{
			if(money < 500)
		    {
			TwoErrorText.SetActive(true);
			return;
		    }
			money -= 500;
			PlayerPrefs.SetInt("Money", money);
			TwoBuy = 1;
			PlayerPrefs.SetInt("TwoBuy", 1);
			TwoErrorText.SetActive(false);
			TwoZamok.SetActive(false);
			TwoPlayButton.text = "Играть";
			return;
		}
		TwoLevelMenu.SetActive(true);
		LvLCheck();
		TwoLevelInfo.SetActive(false);
		LevelsMenu.SetActive(false);
	}
	//Клик кнопки "1" на втором уровне
	public void TwoLvLClickOne()
	{
		if(button_active == 1 || button_active == 3)
		{
			GlobalMenu.SetActive(true);
			TwoLevelMenu.SetActive(false);
			return;
		}
		if(button_active == -5)
		{
			button_active = 1;
			return;
		}else if(button_active == 2)
		{
			button_active = 3;
			return;
		}
	}
	//Клик кнопки "+" на втором уровне
	public void TwoLvLClickPlus()
	{
		if(button_active != 1)
		{
			GlobalMenu.SetActive(true);
			TwoLevelMenu.SetActive(false);
			return;
		}
		button_active = 2;
	}
	//Клик кнопки "*" на втором уровне
	public void TwoLvLClickMultiply()
	{
		if(button_active < 3)
		{
			GlobalMenu.SetActive(true);
			TwoLevelMenu.SetActive(false);
			return;
		}
		button_active = -5;
		money += 2;
		lvl_money += 2;
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetInt("lvl_money", lvl_money);
		TwoLvlTextMoney.text = lvl_money.ToString();
		TextMoney.text = "Баланс: "+money.ToString()+" P$";
	}
	//Покупка третьего уровня (или переход на него, если куплен)
	public void BuyThreeLVL()
	{
		if(ThreeBuy == 0)
		{
			if(money < 1500)
		    {
			ThreeErrorText.SetActive(true);
			return;
		    }
			money -= 1500;
			PlayerPrefs.SetInt("Money", money);
			ThreeBuy = 1;
			PlayerPrefs.SetInt("ThreeBuy", 1);
			ThreeErrorText.SetActive(false);
			ThreeZamok.SetActive(false);
			ThreePlayButton.text = "Играть";
			return;
		}
		ThreeLevelMenu.SetActive(true);
		LvLCheck();
		ThreeLevelInfo.SetActive(false);
		LevelsMenu.SetActive(false);
	}
	//Клик кнопки "1" на третьем уровне
	public void ThreeLvLClickOne()
	{
		if(button_active == 1 || button_active == 3 || button_active == 5)
		{
			GlobalMenu.SetActive(true);
			ThreeLevelMenu.SetActive(false);
			return;
		}
		if(button_active == -5)
		{
			button_active = 1;
			return;
		}else if(button_active == 2)
		{
			button_active = 3;
			return;
		}else if(button_active == 4)
		{
			button_active = 5;
			return;
		}
	}
	//Клик кнопки "+" на третьем уровне
	public void ThreeLvLClickPlus()
	{
		if(button_active != 1)
		{
			GlobalMenu.SetActive(true);
			ThreeLevelMenu.SetActive(false);
			return;
		}
		button_active = 2;
	}
	//Клик кнопки "*" на третьем уровне
	public void ThreeLvLClickMultiply()
	{
		if(button_active != 3)
		{
			GlobalMenu.SetActive(true);
			ThreeLevelMenu.SetActive(false);
			return;
		}
		button_active = 4;
	}
	//Клик кнопки "-" на третьем уровне
	public void ThreeLvLClickMinus()
	{
		if(button_active < 5)
		{
			GlobalMenu.SetActive(true);
			ThreeLevelMenu.SetActive(false);
			return;
		}
		button_active = -5;
		money += 3;
		lvl_money += 3;
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetInt("lvl_money", lvl_money);
		ThreeLvlTextMoney.text = lvl_money.ToString();
		TextMoney.text = "Баланс: "+money.ToString()+" P$";
	}
}
