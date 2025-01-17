namespace 飞机大战
{
    public enum GameState
    {
        NotStart,
        Start,
        // 复合状态，代表敌人飞机，也代表游戏开始
        EnemyPlane,
    }
}