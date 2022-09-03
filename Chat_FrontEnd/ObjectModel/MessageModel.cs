namespace Chat_FrontEnd.ObjectModel
{
    [Serializable]
    public class MessageModel
    {
        public int id { get; set; }

        public int chatId { get; set; }
        public int userId { get; set; }

        public string messageBody { get; set; }
        public DateTime messageDate { get; set; }

        public bool deletedForSelf { get; set; }
    }
}
