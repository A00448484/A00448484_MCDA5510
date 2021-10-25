**Assignment 1**

**Goal** : To write a program that check and read data from all the files present in the main directory and collate that in one file.

**Approach** :
	
	1) Three files in total viz Program.cs, Logger.cs, DirReader.cs.
	2) Logger.cs contains is logger class which logs some of the important events in the program.
	3) DirReader.cs this class file walks through the given directory path and returns names of all the files found.
	4) Program.cs is the main class file which does the required task with help of above two classes. This file iterates over the list of filenames returned by the DirReader and reads contents of those file line by line. As soon as the line is read from the file, it writes to output file on by one.
	   This output file is located inside Output folder. If the program encounters invalid row, it logs the details of it in the log file. Any kind of exception occurs in the execution will be logged.
	   In the end the programs logs total number of valid records, total number of invalid records and total execution time of the program.

**Invalid record condition**:
	1) If both the fields 'First Name' and 'Last Name' of the record are empty, then that record would be counted as invalid.
	2) Some recrods contains garbage values such as "Alm/../..". Those records are also considered invalid.