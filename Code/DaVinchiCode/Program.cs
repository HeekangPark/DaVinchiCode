using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaVinchiCode
{
	public abstract class Card
	{
		/// <summary>
		/// Card의 색상을 나타내는 열거자
		/// </summary>
		public enum CardColor { Black, White }
		/// <summary>
		/// Card의 상태를 나타내는 열거자. Card가 Ground에 있을 때는 OnGround, Participant의 Hand에서 보이는 상태일 때는 Shown, 안 보이는 상태일 때는 Hidden
		/// </summary>
		public enum CardStatus { OnGround, Hidden, Shown }

		/// <summary>
		/// Card의 현재 상태(Ground에 있는지, Participant의 Hand에서 Hidden인지 Shown인지)를 저장하는 변수
		/// </summary>
		protected CardStatus stat;
		public CardStatus Stat
		{
			get { return stat; }
			set { stat = value; }
		}

		//virtual public static int toInt(Card card);
	}

	/// <summary>
	/// 숫자 Card
	/// </summary>
	public class NumCard : Card, IComparable<NumCard>
	{
		private int idx;

		/// <summary>
		/// Card의 값
		/// </summary>
		public int Num
		{
			get { return idx / 2; }
		}

		/// <summary>
		/// Card의 색상
		/// </summary>
		public CardColor Color
		{
			get { return (CardColor)(idx % 2); }
		}

		public NumCard(int idx)
		{
			this.idx = idx;
			stat = CardStatus.OnGround;
		}

		public int CompareTo(NumCard other)
		{
			if (Num > other.Num)
			{
				return 1;
			}
			else if (Num < other.Num)
			{
				return -1;
			}
			else
			{
				if (Color > other.Color)
				{
					return 1;
				}
				else if (Color < other.Color)
				{
					return -1;
				}
				else
				{
					return 0;
				}
			}

		}
	}

	/// <summary>
	/// Joker Card
	/// </summary>
	public class JokerCard : Card { }

	public class Hand
	{
		private List<Card> cards;

		public void AddCard(NumCard card)
		{
			foreach(var item in cards)
			{
				if(item is NumCard)
				{

				}
			}
		}

		public void AddCard(JokerCard card)
		{

		}

	}


	/// <summary>
	/// 게임 참가자를 나타내는 Class
	/// </summary>
	public abstract class Participant
	{
		/// <summary>
		/// Participant가 소속되어 있는 Game을 저장하는 변수
		/// </summary>
		private Game gamecore;
		/// <summary>
		/// Participant의 Hand
		/// </summary>
		private List<Card> hand;
		/// <summary>
		/// Ground로부터 새로 받은 Card를 잡고 있는 변수
		/// </summary>
		private Card newCard;

		/// <summary>
		/// Participant 생성자
		/// </summary>
		/// <param name="gamecore">Participant가 소속되는 Game</param>
		public Participant(Game gamecore)
		{
			this.gamecore = gamecore;
			InitHand();
		}

		/// <summary>
		/// Hand를 Init하는 함수
		/// </summary>
		public void InitHand()
		{
			hand.Clear();
			newCard = null;
		}

		/// <summary>
		/// Hand에 매개변수로 받은 card를 추가하는 함수
		/// </summary>
		/// <param name="card">Hand에 추가할 Card</param>
		public void AddCardtoHand(Card card, Card.Status stat)
		{
			card.Stat = stat;
			hand.Add(card);
		}

		/// <summary>
		/// 다른 Participant의 Guess문의에 답하는 함수
		/// </summary>
		/// <param name="handIdx">Hand에서의 Card의 위치</param>
		/// <param name="guess">Guess하는 Card</param>
		/// <returns>Guess가 맞으면 true, 틀리면 false를 반환</returns>
		public bool GuessResult(int handIdx, Card guess)
		{
			if (hand[handIdx] == guess)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 다른 Participant에게 Card를 문의하는 함수
		/// </summary>
		/// <param name="toWho">문의할 Participant</param>
		/// <param name="handIdx">Hand에서의 Card의 위치</param>
		/// <param name="guess">Guess하는 Card</param>
		public void Guess(Participant toWho, int handIdx, Card guess)
		{

		}

		/// <summary>
		/// Ground에서 Card를 하나 가져온다.
		/// </summary>
		/// <param name="groundIdx"></param>
		public void TakeCard(int groundIdx)
		{

		}
	}

	class Player : Participant
	{
		public Player(Game gamecore) : base(gamecore) { }
	}

	class Bot : Participant
	{
		public Bot(Game gamecore) : base(gamecore) { }
	}

	public List<Card> Ground;



	public class Game
	{
		
	}





	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
