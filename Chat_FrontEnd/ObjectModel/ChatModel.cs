namespace Chat_FrontEnd.ObjectModel
{
    [Serializable]
    public class ChatModel
    {
        public int id { get; set; }
        public string chatName { get; set; }
        public ICollection<UserModel> users { get; set; }
    }
}
