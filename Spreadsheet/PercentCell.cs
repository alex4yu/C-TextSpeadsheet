public class PercentCell : RealCell{

    public PercentCell(string data) : base(data){}
    
    public override string getData(){
        return base.getData();
    }
    public override string getFullData(){
        return getData() + "%";
    }
    public override string gridOutput(){
        string s = getData();
        double d = Double.Parse(s);
        d = (int)(d * 10) / 10.0;
        s = "" + d;
        if(s.Length > 7){
            return s.Substring(0,7) + "%";
        }
        else{
            int leftover = 7 - s.Length;
            string result = s + "%";
            for(int i = 0; i < leftover; i++){
                result += " ";
            }
            return result;
        }
        
    }
    
} 
