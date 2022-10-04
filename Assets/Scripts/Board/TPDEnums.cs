public enum ECellStates
{
    Empty,
    Room,
    Connected,
    Blocked,
    Unvisited = Room | Blocked
};

