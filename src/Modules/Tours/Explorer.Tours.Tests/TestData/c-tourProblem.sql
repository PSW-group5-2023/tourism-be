INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved")
	VALUES (-1, 1, 1, 4, 2, 'Vodic se nije pojavio', CURRENT_TIMESTAMP, false);
INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved")
	VALUES (-2, 2, 2, 0, 1, 'Rezervacija nije sacuvana', CURRENT_TIMESTAMP, false);
INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved")
	VALUES (-3, 3, 2, 0, 1, 'Ne moze se rezervisati ova tura', CURRENT_TIMESTAMP, false);