using System.IO;

public class Start{
    static void Main(){
        try{
            StreamReader sr = new StreamReader("intro.txt");
            string line = sr.ReadLine();
            while(line != null){
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        catch(Exception e){
            Console.WriteLine("Exception: " + e.Message);
        }
        
        Grid spreadsheet = new Grid();
        Console.WriteLine("Enter 'quit' to exit");
        Console.WriteLine("Enter Commands:");
        string command = "";
        command = Console.ReadLine();
        while(!command.Equals("quit")){
            spreadsheet.processCommand(command);
            command = Console.ReadLine();
            if(command.Equals("help")){
                //TODO
            }
        }
        
        
        
    }
}
