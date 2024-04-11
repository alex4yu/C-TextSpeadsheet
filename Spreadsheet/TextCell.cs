public class TextCell : RealCell{

    public TextCell(string data) : base(data){}
    
    public override string getData(){
        return base.getData();
    }
    public override string getFullData(){
        return "\"" + getData() + "\"";
    }
    public override string gridOutput(){
        string s = getData();
        if(s.Length > 8){
            return s.Substring(0,8);
        }
        else{
            int leftover = 8 - s.Length;
            string result = s;
            for(int i = 0; i < leftover; i++){
                result += " ";
            }
            return result;
        }
        
    }
    
} 
