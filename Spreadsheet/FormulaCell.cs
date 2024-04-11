using System;
using System.Data;
public class FormulaCell : RealCell{

    public FormulaCell(string data) : base(data){}
    
    public override string getData(){
        return base.getData();
    }

    public override string getFullData(){
        return "(" + getData() + ")";
    }

    public override string gridOutput(){
        DataTable table = new DataTable();
        
        string s = getData();
        double result = Convert.ToDouble(table.Compute(s, ""));
        s = "" + result;
        if(s.Length > 8){
            return s.Substring(0,8);
        }
        else{
            int leftover = 8 - s.Length;
            string ret = s;
            for(int i = 0; i < leftover; i++){
                ret += " ";
            }
            return ret;
        }
        
    }
    
} 
