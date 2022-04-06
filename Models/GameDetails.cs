namespace ticapi.Models
{
    public class GameDetails{
        public long Id { get; set; }
        public string? Players{get; set;}
        public string? Player1Moves{get; set;}
        public string? Player2Moves{get; set;}
        public string? board{get; set;}
        public int position{get;set;}
        public string? turn{get;set;}
        


    }
}
//post -h Content-Type=application/json -c "{"Players":["test1","test2"],"Player1Moves":[1,2,3,4,5],"Player2Moves":[1,2,3,4,,5],"board":[true,false,false,false]}"