//the entire problem is solved by BAleksiev
//you can find the original code here: https://github.com/BAleksiev/JavaBasics/blob/master/Java-Syntax/src/PainHouseSVG.java
//I am just spreading the word, enjoy!

import java.io.PrintWriter;
import java.util.Scanner;

public class _10PrintHouse {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        
        String inputStr = input.nextLine();
        String inp[] = inputStr.split(" ");
        
        double data[] = new double[2];
        data[0] = Double.parseDouble(inp[0]);
        data[1] = Double.parseDouble(inp[1]);
        
        double coordsX[] = {10, 12.5, 15, 17.5, 20, 22.5};
        double coordsY[] = {3.5, 6, 8.5, 11, 13.5, 16};
        
        // fix point position
        if(data[0] < 8) {
            data[0] = 8;
        } else if(data[0] > 23) {
            data[0] = 23;
        }
        if(data[1] < 2) {
            data[1] = 2;
        } else if(data[1] > 17) {
            data[1] = 17;
        }
        
        double pixelsX = 70 + (70 * ((data[0] - 10) / 2.5));
        double pixelsY = 60 + (70 * ((data[1] - 3.5) / 2.5));
        
        // check if inside the house
        double leftSide = ( (12.5 - 17.5)*(data[1] - 3.5) - (8.5 - 3.5)*(data[0] - 17.5) );
        double rightSide = ( (22.5 - 17.5)*(data[1] - 3.5) - (8.5 - 3.5)*(data[0] - 17.5) );
        
        boolean leftRoof = leftSide <= 0.0;
        boolean rightRoof = rightSide >= 0.0;
        boolean roof = leftRoof == true && rightRoof == true && data[1] <= 8.5;
        
        boolean leftWall = data[1] >= 8.5 && data[1] <= 13.5 && data[0] >= 12.5 && data[0] <= 17.5;
        boolean rightWall = data[1] >= 8.5 && data[1] <= 13.5 && data[0] >= 20 && data[0] <= 22.5;
        boolean walls = leftWall == true || rightWall == true;
        
        // build html code
        String content = "<!DOCTYPE html>\n"
                + "<html>\n"
                + "<body>\n"
                + "\n"
                + "<svg width=\"1000\" height=\"1000\">\n"
                + "  <text x=\"55\" y=\"20\" font-size=\"27\">10</text>\n"
                + "  <text x=\"115\" y=\"20\" font-size=\"27\">12.5</text>\n"
                + "  <text x=\"195\" y=\"20\" font-size=\"27\">15</text>\n"
                + "  <text x=\"255\" y=\"20\" font-size=\"27\">17.5</text>\n"
                + "  <text x=\"335\" y=\"20\" font-size=\"27\">20</text>\n"
                + "  <text x=\"395\" y=\"20\" font-size=\"27\">22.5</text>\n"
                + "\n"
                + "  <text x=\"13\" y=\"70\" font-size=\"27\">3.5</text>\n"
                + "  <text x=\"33\" y=\"140\" font-size=\"27\">6</text>\n"
                + "  <text x=\"13\" y=\"210\" font-size=\"27\">8.5</text>\n"
                + "  <text x=\"20\" y=\"280\" font-size=\"27\">11</text>\n"
                + "  <text x=\"0\" y=\"350\" font-size=\"27\">13.5</text>\n"
                + "  <text x=\"20\" y=\"420\" font-size=\"27\">16</text>\n"
                + "\n"
                + "  <line x1=\"53\" y1=\"60\" x2=\"440\" y2=\"60\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"53\" y1=\"130\" x2=\"440\" y2=\"130\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"53\" y1=\"200\" x2=\"440\" y2=\"200\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"53\" y1=\"270\" x2=\"440\" y2=\"270\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"53\" y1=\"340\" x2=\"440\" y2=\"340\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"53\" y1=\"410\" x2=\"440\" y2=\"410\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "\n"
                + "  <line x1=\"70\" y1=\"30\" x2=\"70\" y2=\"440\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"140\" y1=\"30\" x2=\"140\" y2=\"440\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"210\" y1=\"30\" x2=\"210\" y2=\"440\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"280\" y1=\"30\" x2=\"280\" y2=\"440\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"350\" y1=\"30\" x2=\"350\" y2=\"440\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "  <line x1=\"420\" y1=\"30\" x2=\"420\" y2=\"440\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />\n"
                + "\n";
        
        // add circle
        if(roof == true || walls == true) {
            content += "<circle cx=\""+pixelsX+"\" cy=\""+pixelsY+"\" r=\"5\" fill=\"black\" />\n";
        } else {
            content += "<circle cx=\""+pixelsX+"\" cy=\""+pixelsY+"\" r=\"5\" stroke=\"black\" stroke-width=\"1\" fill=\"#bfbfbf\" />\n";
        }
        
        content += "  <polygon points=\"280,60 420,200 140,200\" style=\"fill:blue;stroke:#002065;stroke-width:2;fill-opacity:0.3;stroke-opacity:0.8\" />\n"
                + "  <rect x=\"140\" y=\"200\" width=\"140\" height=\"140\" style=\"fill:blue;stroke:#002065;stroke-width:2;fill-opacity:0.3;stroke-opacity:0.8\" />\n"
                + "  <rect x=\"350\" y=\"200\" width=\"70\" height=\"140\" style=\"fill:blue;stroke:#002065;stroke-width:2;fill-opacity:0.3;stroke-opacity:0.8\" />\n"
                + "</svg>\n"
                + " \n"
                + "</body>\n"
                + "</html>\n";
        
        try {
            
            // create html file and fill with the html content
            PrintWriter writer = new PrintWriter("house.html", "UTF-8");
            writer.println(content);
            writer.close();

        } catch (Exception e) {
        }
    }
}