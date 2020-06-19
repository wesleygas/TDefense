public static class GameState
{
    public static int coins = 0;
    public static int habitants = 10;
    public static int maxHabitants = 10;


    public static void reset()
    {
        habitants = maxHabitants;
        coins = 0;
    }
}