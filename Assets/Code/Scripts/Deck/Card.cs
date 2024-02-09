public class Card {
	public enum CardType {
		SkipTurn,
		Joker,
		PlusOne,
		Bullet,
		DrawTwo,
	}

	int _cardValue = 0;
	CardType _cardType = CardType.SkipTurn;
	
	public Card(CardType cardType, int cardValue)
	{
		_cardType = cardType;
		_cardValue = cardValue;
		
	}
	
	public int GetGraphicalCardValue() => _cardValue + 1;
	
}