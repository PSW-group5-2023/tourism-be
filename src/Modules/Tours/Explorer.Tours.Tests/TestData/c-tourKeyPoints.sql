INSERT INTO tours."TourKeyPoints"(
    "Id", "Name", "Description", "Image", "Latitude", "Longitude", "TourId", "Discriminator", "Status", "CreatorId")
VALUES (-1, 'Tacka 1', 'Tacka 1 je prva tacka', 'http://tacka1.com/', 24.22, 12.3, -1, 'TourKeyPoint', null, null);

INSERT INTO tours."TourKeyPoints"(
    "Id", "Name", "Description", "Image", "Latitude", "Longitude", "TourId", "Discriminator", "Status", "CreatorId")
VALUES (-2, 'Tacka 2', 'Tacka 2 je prva tacka', 'http://tacka2.com/', -24.22, -12.3, -1, 'TourKeyPoint', null, null);

INSERT INTO tours."TourKeyPoints"(
    "Id", "Name", "Description", "Image", "Latitude", "Longitude", "TourId", "Discriminator", "Status", "CreatorId")
VALUES (-3, 'Tacka 3', 'Tacka 3 je prva tacka', 'http://tacka3.com/', -64.22, 82.3, -2, 'TourKeyPoint', null, null);

INSERT INTO tours."TourKeyPoints"(
    "Id", "Name", "Description", "Image", "Latitude", "Longitude", "TourId", "Discriminator", "Status", "CreatorId")
VALUES (-4, 'Tacka 4 public', 'Tacka 3 je prva tacka', 'http://tacka3.com/', -64.22, 82.3, -2, 'PublicTourKeyPoints', 2, 11);

INSERT INTO tours."TourKeyPoints"(
    "Id", "Name", "Description", "Image", "Latitude", "Longitude", "TourId", "Discriminator", "Status", "CreatorId")
VALUES (-5, 'Tacka 5 public', 'Tacka 3 je prva tacka', 'http://tacka3.com/', -64.22, 82.3, -2, 'PublicTourKeyPoints', 2, 11);