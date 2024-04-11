public class NullCell : Cell{

    private string data;
    public NullCell(){
        data = "";
    }
    public string getData(){
        return data;
    }
    public string getFullData(){
        return data;
    }
    public string gridOutput(){
        //grid spaces are 8 characters long
        return "        ";
    }
} 
