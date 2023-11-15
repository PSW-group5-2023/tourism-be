INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved", "Messages", "Deadline")
VALUES 
	(-1, -8, -3, 0, 1, 'Rezervacija nije sacuvana', CURRENT_TIMESTAMP, false, '[
	  {
		"SenderId": -3,
	  	"RecipientId": -8,
		"CreationTime": "2023-11-11T15:03:36.2030688Z",
		"Description": "Problem u sistemu je u procesu resavanja. Rezervacija ce biti omogucena u narednih nekoliko sati. ",
		"IsRead": false
	  },
	  {
		"SenderId": -8,
	  	"RecipientId": -3,
		"CreationTime": "2023-11-11T17:03:36.2030688Z",
		"Description": "Jos uvek nije moguce izvrsiti rezervaciju. ",
		"IsRead": false
	  }
	]', null);
INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved", "Messages", "Deadline")
VALUES 
	(-2, -6, -3, 2, 2, 'Dodatni troskovi su naplaceni, a nisu bili navedeni prilikom rezervacije. ', CURRENT_TIMESTAMP, false, '[
	  {
		"SenderId": -3,
	  	"RecipientId": -6,
		"CreationTime": "2023-11-13T20:03:36.2030688Z",
		"Description": "Dodatni troskovi su sada azurirani i vidljivi prilikom rezervacije. ",
		"IsRead": false
	  }
	]', null);
INSERT INTO tours."TourProblems"(
	"Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved", "Messages", "Deadline")
VALUES 
	(-3, -6, -3, 0, 4, 'Bilo je problema sa organizacijom', CURRENT_TIMESTAMP, false, '[]', null);