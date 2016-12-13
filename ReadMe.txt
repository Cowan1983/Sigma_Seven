The "Features.txt" and "FeaturesTiDelete.txt" files need to be in the same directory as the "Sigam_seven_Test.exe".
The results file will be called "Filtered.txt".

The Debug directory in the project contains the test data I was (eventually) provided with.

On my computer the test data takes 35 seconds to process. I have various ideas about how to speed this up, but as the test
was supposed to have a 1.5 hour limit, I feel I should provide you with my first implementation, and not attempt to
fine tune the code with ideas I have had subsequently.


Ideas include:


Using a SortedList for the List<> of UDNs to be deleted. The .Contains(...) function will run quicker

Using a Lamda statement to compare lines in the Features.txt to the contents of the List<> of UDNs to delete.

Putting the Features.txt into a Dictionary<UDN, Line Contents>, iterating through the FeaturesToDelete.txt and 
removing the matching entries in the dictionsry. Then write out the dictionary values to a file.


Whether any of these would have helped I will find out now that I have posted the code.
