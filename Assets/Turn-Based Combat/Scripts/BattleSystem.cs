using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public GameObject Fill;
	public GameObject EnemyFill;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	public Button AttackButton;
	public Button HealButton; 

	Unit playerUnit;
	Unit enemyUnit;

	public TMP_Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

	// Start is called before the first frame update
	void Start()
	{
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{

		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = "The " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(3f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		AttackButton.gameObject.SetActive(false);
		HealButton.gameObject.SetActive(false);
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if (isDead)
		{
			EnemyFill.gameObject.SetActive(false);
			state = BattleState.WON;
			EndBattle();
		}
		else
		{

			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator KatanaAttack()
	{
		AttackButton.gameObject.SetActive(false);
		HealButton.gameObject.SetActive(false);
		bool isDead = enemyUnit.TakeKatanaDamage(playerUnit.KatanaDamage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator PlaneAttack()
	{
		AttackButton.gameObject.SetActive(false);
		HealButton.gameObject.SetActive(false);
		bool isDead = enemyUnit.TakePlaneDamage(playerUnit.PlaneDamage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if (isDead)
		{
			Fill.gameObject.SetActive(false);
			state = BattleState.LOST;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		StartCoroutine(endBattle());
	}

	IEnumerator endBattle()
	{
		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
			yield return new WaitForSeconds(6f);
			SceneManager.LoadScene("Win");
		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
			yield return new WaitForSeconds(6f);
			SceneManager.LoadScene("Lose");
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";

		AttackButton.gameObject.SetActive(true);
		HealButton.gameObject.SetActive(true);

	}

	IEnumerator PlayerHeal()
	{
		AttackButton.gameObject.SetActive(false);
		HealButton.gameObject.SetActive(false);
		playerUnit.Heal(6);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnKatanaButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(KatanaAttack());
	}

	public void OnPlaneButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlaneAttack());
	} 

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}