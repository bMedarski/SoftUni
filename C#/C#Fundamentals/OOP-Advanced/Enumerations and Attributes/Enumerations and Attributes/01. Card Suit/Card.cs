using System;

public class Card:IComparable<Card>
{
	private Cards suit;
	private CardTypes cardType;

	public Card(string suit, string cardType)
	{
		this.suit = (Cards) Enum.Parse(typeof(Cards), suit);
		this.cardType = (CardTypes)Enum.Parse(typeof(CardTypes), cardType); ;
	}

	private int GetCardValue()
	{
		return (int) this.suit + (int) this.cardType;
	}

	public int CompareTo(Card other)
	{
		return this.GetCardValue().CompareTo(other.GetCardValue());
	}

	public override string ToString()
	{
		return $"Card name: {this.cardType} of {this.suit}; Card power: {this.GetCardValue()}";
	}
}




