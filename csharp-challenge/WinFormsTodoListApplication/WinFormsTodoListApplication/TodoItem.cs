namespace WinFormsTodoListApplication
{
    class TodoItem
    {
        public int Priority { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; } = false;

        public string DisplayTodo => $"{ Priority } { Name }";
    }
}
