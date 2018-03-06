namespace BookvikSupport
{
    public class BindingModel
    {
        public class Book
        {
            public string NameBook { get; set; }
            public int Id { get; set; }
        }
        public class Page
        {
            public int PlaceInGroup;
            public string Number;
            public string Name;
            public string Type;
            public string Model;
            public string YoutubeLink1;
            public string YoutubeLink2;
            public string GameLink1;
            public string GameLink2;
            public int BookId;

            public Page(int placeInGroup, string number, string name, string type, string model, string youtubeLink1, string youtubeLink2, string gameLink1, string gameLink2, int bookId)
            {
               
                PlaceInGroup = placeInGroup;
                Number = number;
                Name = name;
                Type = type;
                Model = model;
                YoutubeLink1 = youtubeLink1;
                YoutubeLink2 = youtubeLink2;
                GameLink1 = gameLink1;
                GameLink2 = gameLink2;
                BookId = bookId;
            }
        }
    }
}