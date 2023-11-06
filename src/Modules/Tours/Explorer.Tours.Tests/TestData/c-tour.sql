INSERT INTO tours."Tour"(
"Id", "Name", "Description", "Difficulty", "Tags", "Status", "Price", "AuthorId", "Equipment", "ArchivedDate")
VALUES (-1, 'Tura 1', 'Ova tura je lepa', 'BEGINNER', '#tag1', 1, 0, -1, '{{-1, -2}}', NULL);
INSERT INTO tours."Tour"(
"Id", "Name", "Description", "Difficulty", "Tags", "Status", "Price", "AuthorId", "Equipment", "ArchivedDate")
VALUES (-2, 'Tura 2', 'Ova tura je okej', 'INTERMEDIATE', '#tag2', 1, 0, -2, '{{-1}}', NULL);
INSERT INTO tours."Tour"(
"Id", "Name", "Description", "Difficulty", "Tags", "Status", "Price", "AuthorId", "Equipment", "ArchivedDate")
VALUES (-3, 'Tura 3', 'Ova tura je super', 'PRO', '#tag2', 2, 0, -3, '{{-1, -3}}', NULL);

--VALUES (-1, 'Tura 1', 'Ova tura je lepa', 'BEGINNER', '#tag1', 'DRAFT', 0, -1, ARRAY[-1,-2,-3]);
--INSERT INTO tours."Tour"(
--"Id", "Name", "Description", "Difficulty", "Tags", "Status", "Price", "AuthorId", "Equipment")
--VALUES (-2, 'Tura 2', 'Ova tura je okej', 'INTERMEDIATE', '#tag2', 'DRAFT', 0, -2, ARRAY[-1,-2, -3]);
--INSERT INTO tours."Tour"(
--"Id", "Name", "Description", "Difficulty", "Tags", "Status", "Price", "AuthorId", "Equipment")
--VALUES (-3, 'Tura 3', 'Ova tura je super', 'PRO', '#tag2', 'DRAFT', 0, -3, ARRAY[-1,-2, -3]);

