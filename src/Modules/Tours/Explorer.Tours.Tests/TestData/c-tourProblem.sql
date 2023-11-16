INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved","Messages","Deadline")
	VALUES (-1, -21, -1, 4, 2, 'Vodic se nije pojavio', CURRENT_TIMESTAMP, false, 
			'{
			  "UserId": 1,
			  "CreationTime": "2023-11-07T12:34:56.789Z",
			  "Description": "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
			  "IsRead":false
			}',NULL );
INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved","Messages","Deadline")
	VALUES (-2, -22, -2, 0, 1, 'Rezervacija nije sacuvana', CURRENT_TIMESTAMP, false,
		   '{
			  "UserId": 1,
			  "CreationTime": "2023-11-07T12:34:56.789Z",
			  "Description": "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
			  "IsRead":false
			}',null);
INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved","Messages","Deadline")
	VALUES (-3, -21, -2, 0, 1, 'Ne moze se rezervisati ova tura', CURRENT_TIMESTAMP, false, 
		   '{
			  "UserId": 1,
			  "CreationTime": "2023-11-07T12:34:56.789Z",
			  "Description": "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
			  "IsRead":false
			}',null );