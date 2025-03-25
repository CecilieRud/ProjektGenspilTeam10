namespace Genspilv2.Rud
{
    public class Game(State currentState, double totalPrice)
    {
        private State CurrentState { get; set; } = currentState;
        private double TotalPrice { get; set; } = totalPrice;

        public double GetPrice()
        {
            return CurrentState switch
            {
                State.Ny => TotalPrice * 0.9,
                State.God => TotalPrice * 0.8,
                State.Brugt => TotalPrice * 0.6,
                State.MegetBrugt => TotalPrice * 0.4,
                _ => throw new Exception(),
            };
        }
    }
    public enum State
    {
        Ny,
        God,
        Brugt,
        MegetBrugt
    }
}