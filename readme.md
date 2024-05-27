How to start:

TL;DR
Use the following command in the same directory as the exe-file

		DailyObserverDownloader.exe -releasesFile "[Path to this directory]\releases.txt" -downloadPath "[Path to this directory]\PDFs" -deleteSinglePagesFlag "y"

Programm can be started by using the exe file. 
The following argument can be given:
- -releasesFile
  - The path where the textfile with all releases lies
  - The files should have the following structure

		19820105
		19820106
		19820107
		19820108
		19820118
		19820119
		19820120
		...
  - By default the path: "C:\\daily_observer\\releases.txt"	

- -downloadPath
  - The path where the pdfs should be downloaded to
  - By default the path: "C:\\daily_observer\\PDFs";

- -deleteSinglePagesFlag 
  - Option to have the single pages deleted
  - Can either be "y" for deleting or "n" for leaving the pages in the folder
  - By default: "y"

Notes:
- Firefox has to be installed

