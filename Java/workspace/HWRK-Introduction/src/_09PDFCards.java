import java.io.FileOutputStream;
import java.io.IOException;

import com.itextpdf.text.*;
import com.itextpdf.text.pdf.*;

//we use itext library, you can find great tutorial here http://www.vogella.com/tutorials/JavaPDF/article.html
//download the library from here http://sourceforge.net/projects/itext/
public class _09PDFCards {
    
	private static String FILE = "_09PDFCards.pdf";
	
	public static void main(String[] args) {
		
		System.out.println();
		
		try {
		      Document document = new Document(); 
		      PdfWriter.getInstance(document, new FileOutputStream(FILE));
		      document.open();
		      addContent(document);
		      document.close();
		    } catch (Exception e) {
		      e.printStackTrace();
		    }
	}

private static void addContent(Document document) throws DocumentException, IOException {
	
	//set arrays with card numbers and suits
	String[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
	char[] suits = {'\u2665', '\u2663', '\u2666', '\u2660'};
	
	//create font that supports the card suits
	BaseFont baseFont = BaseFont.createFont("times.ttf", BaseFont.IDENTITY_H, true);
    Font deckFont = new Font(baseFont, 12f);
    Font deckFontRed = new Font(baseFont, 12f);
	deckFontRed.setColor(BaseColor.RED);
	
    //we will create the containing big table that has no borders and contains all cards
	//inside every cell of this table we have a small table
	//with borders that represents every playing card
    PdfPTable tableContainer = new PdfPTable(4);
    tableContainer.getDefaultCell().setBorder(0);
    
    //generating the cards in two nested loops
	for (int i = 0; i < 13; i++){
		for (int j = 0; j < 4; j++){
			
			//we make sure that the hearts and the clubs are red
			if (j == 0 || j == 2){
				makeTableWithCard(cards, suits, deckFontRed, tableContainer, i, j);
			}
			else {
				makeTableWithCard(cards, suits, deckFont, tableContainer, i, j);
			}
		}
	}
	//we add the containing big table to the PDF file
	document.add(tableContainer);
  }

	private static void makeTableWithCard(String[] cards, char[] suits,
		Font deckFontRed, PdfPTable tableContainer, int i, int j) {
		
		//every loop we create one table with certain width and height
		PdfPTable table = new PdfPTable(1);
		table.getDefaultCell().setFixedHeight(45);
		table.setTotalWidth(30);
		table.setLockedWidth(true);
		table.getDefaultCell().setVerticalAlignment(Element.ALIGN_MIDDLE);
		table.getDefaultCell().setHorizontalAlignment(Element.ALIGN_CENTER);
		
		//we fill the table with card and suit
		String cellContent = (cards[i] + suits[j]);
		table.addCell(new Phrase(cellContent, deckFontRed));
		tableContainer.addCell(table);
	}
}
