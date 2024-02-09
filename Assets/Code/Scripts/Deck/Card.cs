public class Card {
    enum CardType {
        SkipTurn,
        Joker,
        PlusOne,
        Bullet,
        DrawTwo,
    }

    int cardValue = 0;
    CardType cardType = CardType.SkipTurn;
}