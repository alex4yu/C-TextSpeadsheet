using System.Runtime.CompilerServices;

public class Grid{
    Cell[,] grid;

    public Grid(){
        grid = new Cell[10,10];
        for(int i = 0; i < 10; i++){
            for(int j = 0; j < 10; j++){
                grid[i,j] = new NullCell();
            }
        }
    }
    
 
    private string getGrid(){
        string g = "  |1       |2       |3       |4       |5       |6       |7       |8       |9       |10      |\n";

        for(int i  = 0; i < 10; i++){
            char letter = (char)(i + 65);
            string rowString = letter + " |";
            for(int j = 0; j < 10; j++){
                rowString += grid[i,j].gridOutput() + "|";
            }
            g += rowString + "\n";
        }
        return g;
    }
    private void printGrid(){
        
       Console.Write(getGrid());
    }

    public void processCommand(string command){

        if(command.Length == 2 || command.Length == 3){
            int row = letterToInt(command.Substring(0,1));
            int col = Int32.Parse(command.Substring(1));
            Console.WriteLine("" + command.Substring(0,1) + col + " = " + grid[row - 1, col - 1].getFullData());
        }
        else if(command.Equals("print grid")){
            printGrid();
        }
        // if the file doesn't already exist it will create one with the given name. 
        else if (command.IndexOf("copy grid") == 0){
            string fn = command.Substring(10);
            if(!File.Exists(fn)){
                File.Create(fn);
            }
            try{
                StreamWriter sw = new StreamWriter(fn);
                sw.Write(getGrid());
                sw.Close();
            }
            catch(Exception e){
                Console.WriteLine("Exception: " + e.Message);
            }

        }
        else if(command.IndexOf("= \"") != -1){
            int row = letterToInt(command.Substring(0,1));
            int col = Int32.Parse(command.Substring(1, command.IndexOf("=") - 2));
            string data = command.Substring(command.IndexOf("\"") + 1, command.Length - command.IndexOf("\"") - 2);
            TextCell tc = new TextCell(data);
            grid[row - 1, col - 1] = tc;
            printGrid();
        }
        else if(command.IndexOf("(") != -1){
            int row = letterToInt(command.Substring(0,1));
            int col = Int32.Parse(command.Substring(1, command.IndexOf("=") - 2));
            string data = command.Substring(command.IndexOf("(") + 1, command.Length - command.IndexOf("(") - 2);
            FormulaCell tc = new FormulaCell(data);
            grid[row - 1, col - 1] = tc;
            printGrid();
        }
        else if(command.IndexOf("%") != -1){
            int row = letterToInt(command.Substring(0,1));
            int col = Int32.Parse(command.Substring(1, command.IndexOf("=") - 2));
            string data = command.Substring(command.IndexOf("=") + 1, command.IndexOf("%") - command.IndexOf("=") - 1);
            PercentCell pc = new PercentCell(data);
            grid[row - 1, col - 1] = pc;
            printGrid();
        }
        
        

    }

    //input letter must be a single character
    private int letterToInt(string letter){
        letter = letter.ToUpper();
        char[] letterChar = letter.ToCharArray();
        return (int)letterChar[0] - 64;
    }
}