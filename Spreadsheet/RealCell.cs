public class RealCell : Cell{

    protected string data;
    public RealCell(string data){
        this.data = data;
    }
    
    public virtual string getData(){
        return data;
    }
    public virtual string getFullData(){
        return data;
    }
    public virtual string gridOutput(){
        //grid spaces are 8 characters long
        return "        ";
    }
    
} 
