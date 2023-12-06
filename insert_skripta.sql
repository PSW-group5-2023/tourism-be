INSERT INTO stakeholders."Users"("Id", "Username", "Password", "Role", "IsActive")
VALUES 
	(-1, 'admin', 'admin', 0, true),
	(-2, 'jane_smith', 'admin', 0, true),
	(-3, 'author', 'author', 1, true),
	(-4, 'olivia_wilson', 'author', 1, true),
	(-5, 'daniel_taylor', 'author', 1, true),
	(-6, 'tourist', 'tourist', 2, true),
	(-7, 'sophia_brown', 'tourist', 2, false),
	(-8, 'ethan_clark', 'tourist', 2, true),
	(-9, 'ava_young', 'tourist', 2, false),
	(-10, 'james_brown', 'admin', 0, true);


INSERT INTO stakeholders."People"("Id", "UserId", "Name", "Surname", "Email", "ProfilePic", "Biography", "Motto")
VALUES 
    (-1, -1, 'Admin', 'Admin', 'john.doe@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Carpe Diem'),
    (-2, -2, 'Jane', 'Smith', 'jane.smith@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'Live in the moment'),
    (-3, -3, 'Author', 'Author', 'james.brown@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 'Stay positive'),
    (-4, -4, 'Emily', 'Johnson', 'emily.johnson@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.', 'Spread love'),
    (-5, -5, 'Michael', 'Davis', 'michael.davis@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'Be yourself'),
	  (-6, -6, 'Tourist', 'Tourist', 'olivia.wilson@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.', 'Chase your dreams'),
    (-7, -7, 'Daniel', 'Taylor', 'daniel.taylor@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.', 'Embrace the journey'),
    (-8, -8, 'Sophia', 'Brown', 'sophia.brown@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'Believe in yourself'),
    (-9, -9, 'Ethan', 'Clark', 'ethan.clark@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam.', 'Explore the unknown'),
    (-10, -10, 'Ava', 'Young', 'ava.young@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.', 'Create your own destiny');

INSERT INTO blog."Blogs"(
	"Id", "Title", "Description", "CreationDate", "Status", "UserId", "RatingSum", "Ratings")
	VALUES (-22, 'Neki blog','Marked - Markdown Parser
========================

[Marked] lets you convert [Markdown] into HTML.  Markdown is a simple text format whose goal is to be very easy to read and write, even when not converted to HTML.  This demo page will let you type anything you like and see how it gets converted.  Live.  No more waiting around.

How To Use The Demo
-------------------

1. Type in stuff on the left.
2. See the live updates on the right.

Thats it.  Pretty simple.  Theres also a drop-down option above to switch between various views:

- **Preview:**  A live display of the generated HTML as it would render in a browser.
- **HTML Source:**  The generated HTML before your browser makes it pretty.
- **Lexer Data:**  What [marked] uses internally, in case you like gory stuff like this.
- **Quick Reference:**  A brief run-down of how to format things using markdown.

Why Markdown?
-------------

Its easy.  Its not overly bloated, unlike HTML.  Also, as the creator of [markdown] says,

> The overriding design goal for Markdowns
> formatting syntax is to make it as readable
> as possible. The idea is that a
> Markdown-formatted document should be
> publishable as-is, as plain text, without
> looking like its been marked up with tags
> or formatting instructions.

Ready to start writing?  Either start changing stuff on the left or
[clear everything](/demo/?text=) with a simple click.

[Marked]: https://github.com/markedjs/marked/
[Markdown]: http://daringfireball.net/projects/markdown/' ,CURRENT_TIMESTAMP, 3, -3, 2, '[
  {
    "UserId": -4,
    "RatingValue": 1,
    "CreationDate": "0001-01-01T00:00:00"
  },
  {
    "UserId": -3,
    "RatingValue": 1,
    "CreationDate": "2023-11-07T13:41:45.5877444Z"
  },
  {
    "UserId": -5,
    "RatingValue": 1,
    "CreationDate": "2023-11-07T15:03:36.2030688Z"
  },
  {
    "UserId": -6,
    "RatingValue": -1,
    "CreationDate": "2023-11-08T22:36:10.1609977Z"
  }
]');
INSERT INTO blog."Blogs"(
	"Id", "Title", "Description", "CreationDate", "Status", "UserId", "RatingSum", "Ratings")
	VALUES (-21, 'Neki blog2','Marked - Markdown Parser
========================

[Marked] lets you convert [Markdown] into HTML.  Markdown is a simple text format whose goal is to be very easy to read and write, even when not converted to HTML.  This demo page will let you type anything you like and see how it gets converted.  Live.  No more waiting around.

How To Use The Demo
-------------------

1. Type in stuff on the left.
2. See the live updates on the right.

Thats it.  Pretty simple.  Theres also a drop-down option above to switch between various views:

- **Preview:**  A live display of the generated HTML as it would render in a browser.
- **HTML Source:**  The generated HTML before your browser makes it pretty.
- **Lexer Data:**  What [marked] uses internally, in case you like gory stuff like this.
- **Quick Reference:**  A brief run-down of how to format things using markdown.

Why Markdown?
-------------

Its easy.  Its not overly bloated, unlike HTML.  Also, as the creator of [markdown] says,

> The overriding design goal for Markdowns
> formatting syntax is to make it as readable
> as possible. The idea is that a
> Markdown-formatted document should be
> publishable as-is, as plain text, without
> looking like its been marked up with tags
> or formatting instructions.

Ready to start writing?  Either start changing stuff on the left or
[clear everything](/demo/?text=) with a simple click.

[Marked]: https://github.com/markedjs/marked/
[Markdown]: http://daringfireball.net/projects/markdown/' ,CURRENT_TIMESTAMP, 1, -6, 2, '[
  {
    "UserId": -4,
    "RatingValue": 1,
    "CreationDate": "0001-01-01T00:00:00"
  },
  {
    "UserId": -3,
    "RatingValue": 1,
    "CreationDate": "2023-11-07T13:41:45.5877444Z"
  },
  {
    "UserId": -5,
    "RatingValue": 1,
    "CreationDate": "2023-11-07T15:03:36.2030688Z"
  },
  {
    "UserId": -6,
    "RatingValue": -1,
    "CreationDate": "2023-11-08T22:36:10.1609977Z"
  }
]');


INSERT INTO blog."Comments"(
	"Id", "UserId", "CreationDate", "Description", "LastEditDate", "BlogId")
	VALUES 	(-3, -6, CURRENT_TIMESTAMP, 'Neki com',CURRENT_TIMESTAMP , -22),
			(-2, -7, CURRENT_TIMESTAMP, 'Neki com2',CURRENT_TIMESTAMP , -22),
			(-1, -8, CURRENT_TIMESTAMP, 'Neki com3',CURRENT_TIMESTAMP , -22);

INSERT INTO tours."Facilities"("Id", "Name", "Description", "Image", "Category", "Latitude", "Longitude", "Discriminator", "Status", "CreatorId")
VALUES 
  (-1, 'Restoran Kod Bake', 'Palacinkarina', 'https://hypetv.rs/wp-content/uploads/2022/12/baka-prase.jpeg', 1, 52.4324, 52.4123, 'Facility', null, null),
  (-2, 'Javni wc', 'Ovde mozete izvrsiti veliku i malu nuzdu', 'https://naturoplex.com/wp-content/uploads/2018/08/da-li-javni-toaleti-mogu-prouzrokovati-urinarnu-infekciju-naslovna-1.png', 0, 34.6543, 12.3544, 'Facility', null, null),
  (-3, 'Parking', 'Mesto gde mozete da ostavite vase vozilo', 'https://www.mycity.rs/thumbs4/295872_tmb_735147301_13912895_666347850179892_1004021860248568801_n.jpg', 3, 45.0000, 1.4354, 'Facility', null, null);

INSERT INTO tours."Tour"("Id", "Name", "Description", "Difficulty", "Tags", "Status", "Price", "AuthorId", "Equipment", "DistanceInKm", "ArchivedDate", "PublishedDate", "Durations")
VALUES
  (-1, 'Tura 1', 'Ova tura je lepa', 0, '{"tag", "tag2"}', 0, 0, -3, '{-1, -2}', 3.484371, NULL, NULL, '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-2, 'Tura 2', 'Ova tura je okej', 1, '{"tag", "tag2"}', 1, 0, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-3, 'Tura 3', 'Ova tura je super', 3, '{"tag", "tag2"}', 2, 0, -3, '{-1, -3}', 3.484371,  '2023-11-16 18:33:42.718996+01', '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-4, 'Tura 4', 'Ova tura je super', 3, '{"tag", "tag2"}', 1, 0, -3, '{-1, -3}', 3.484371,  '2023-11-16 18:33:42.718996+01', '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-5, 'Tura za javne 1, 2', 'Ova tura je okej', 1, '{"forest", "nature"}', 1, 0, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-6, 'Tura za javne 1, 3, 4', 'Ova tura je okej', 3, '{"history", "walking"}', 1, 0, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-7, 'Tura za javne 4, 5', 'Ova tura je okej', 2, '{"forest"}', 1, 0, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-8, 'Tura za javne 2, 3, 4', 'Ova tura je okej', 0, '{"history", "culture"}', 1, 0, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),


INSERT INTO tours."Equipment"("Id", "Name", "Description")
VALUES
	(-1, 'Voda', 'Količina vode varira od temperature i trajanja ture. Preporuka je da se pije pola litre vode na jedan sat umerena fizičke aktivnosti (npr. hajk u prirodi bez značajnog uspona) po umerenoj vrućini'),
	(-2, 'Štapovi za šetanje', 'Štapovi umanjuju umor nogu, pospešuju aktivnost gornjeg dela tela i pružaju stabilnost na neravnom terenu.'),
	(-3, 'Obična baterijska lampa', 'Baterijska lampa od 200 do 400 lumena.');

INSERT INTO tours."TourKeyPoints"("Id", "Name", "Description", "Image", "Latitude", "Longitude", "TourId", "Discriminator", "Status", "CreatorId", "Secret", "PositionInTour", "PublicPointId")
VALUES 
  (-1, 'Tacka 1', 'Tacka 1 je prva tacka', 'https://images-ext-2.discordapp.net/external/ljZOhTSwyFRfZEj2kDekFTtL_N_fFEP2-oEvCKxTPpI/https/randomwordgenerator.com/img/picture-generator/hakan-aldrin-NSnXEpIl6xs-unsplash.jpg?width=874&height=655', 45.24079195945318, 19.820365905761722, -1, 'TourKeyPoint', null, null, 'Secret 2', 1, null),
  (-2, 'Tacka 2', 'Tacka 2 je druga tacka', 'https://images-ext-2.discordapp.net/external/ljZOhTSwyFRfZEj2kDekFTtL_N_fFEP2-oEvCKxTPpI/https/randomwordgenerator.com/img/picture-generator/hakan-aldrin-NSnXEpIl6xs-unsplash.jpg?width=874&height=655', 45.25783231694552, 19.84560012817383, -1, 'TourKeyPoint', null, null, 'Secret 2', 2, null),
  (-3, 'Tacka 1', 'Tacka 1 je prva tacka', 'https://www.travelandleisure.com/thmb/O_l4b5JDWtEWKQ7mE7PoA3rQdVk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/cascade-mountains-range-USMNTNS0720-db9bdf21ee2e47b1868232c551c01006.jpg', 44.8125, 20.4612, -2, 'TourKeyPoint', null, null, 'Secret 2', 1, null),
  (-4, 'Tacka 2', 'Tacka 2 je druga tacka', 'https://i.insider.com/5a2586ab3339b038248b45ab?width=1000&format=jpeg&auto=webp', 44.1111, 20.5589, -2, 'TourKeyPoint', null, null, 'Secret 2', 2, null),
  (-5, 'Tacka 1', 'Tacka 1 je prva tacka', 'https://images-ext-2.discordapp.net/external/ljZOhTSwyFRfZEj2kDekFTtL_N_fFEP2-oEvCKxTPpI/https/randomwordgenerator.com/img/picture-generator/hakan-aldrin-NSnXEpIl6xs-unsplash.jpg?width=874&height=655', 45.24079195945318, 19.820365905761722, -3, 'TourKeyPoint', null, null, 'Secret 2', 1, null),
  (-6, 'Tacka 2', 'Tacka 2 je druga tacka', 'https://images-ext-2.discordapp.net/external/ljZOhTSwyFRfZEj2kDekFTtL_N_fFEP2-oEvCKxTPpI/https/randomwordgenerator.com/img/picture-generator/hakan-aldrin-NSnXEpIl6xs-unsplash.jpg?width=874&height=655', 45.232164904903826, 19.794790780707856, -3, 'TourKeyPoint', null, null, 'Secret 2', 2, null),
  (-7, 'Tacka 1', 'Tacka 1 je prva tacka', 'https://i.insider.com/5a2586ab3339b038248b45ab?width=1000&format=jpeg&auto=webp', 45.24616355261428, 19.820365905761722, -4, 'TourKeyPoint', null, null, 'Secret 2', 1, null),
  (-8, 'Tacka 2', 'Tacka 2 je druga tacka', 'https://www.travelandleisure.com/thmb/O_l4b5JDWtEWKQ7mE7PoA3rQdVk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/cascade-mountains-range-USMNTNS0720-db9bdf21ee2e47b1868232c551c01006.jpg', 45.24628421561786, 19.843760255270002, -4, 'TourKeyPoint', null, null, 'Secret 2', 2, null),
  (-9, 'Javna 1', 'Lepa kt', 'https://www.snow-forecast.com/system/images/36932/large/Crystal-Mountain.jpg?1619614348', 45.232164904903826, 19.794790780707856, null, 'PublicTourKeyPoints', 0, -3, '', null, null),
  (-10, 'Javna 2', 'Lepsa kt', 'https://plus.unsplash.com/premium_photo-1673859055803-593f6cda5e2b?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fHNub3clMjBtb3VudGFpbnxlbnwwfHwwfHx8MA%3D%3D', 45.24616355261428, 19.820365905761722, null, 'PublicTourKeyPoints', 0, -3, '', null, null),
  (-11, 'Javna 3', 'Najlepsa kt', 'https://wallpapers.com/images/featured/snow-mountain-ydg6x966wun8nkjs.jpg', 45.24628421561786, 19.84560012817383, null, 'PublicTourKeyPoints', 0, -3, '', null, null),
  (-12, 'Javna 4', 'nova javna kt', 'https://cdn.britannica.com/97/158797-050-ABECB32F/North-Cascades-National-Park-Lake-Ann-park.jpg', 45.22383648719875, 19.846165773318674, null, 'PublicTourKeyPoints', 0, -3, '', null, null),
  (-13, 'Javna 5', 'najnovija javna kt', 'https://cdn.britannica.com/95/136995-050-6209F94F/rainforest-Malaysia.jpg', 45.22830260204978, 19.79891452593411, null, 'PublicTourKeyPoints', 0, -3, '', null, null),
  (-14, 'Javna 1 (u turi -5)', 'Lepa kt', 'https://www.snow-forecast.com/system/images/36932/large/Crystal-Mountain.jpg?1619614348', 45.232164904903826, 19.794790780707856, -5, 'TourKeyPoint', null, null, '', 1, -9),
  (-15, 'Javna 2 (u turi -5)', 'Lepsa kt', 'https://plus.unsplash.com/premium_photo-1673859055803-593f6cda5e2b?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fHNub3clMjBtb3VudGFpbnxlbnwwfHwwfHx8MA%3D%3D', 45.24616355261428, 19.820365905761722, -5, 'TourKeyPoint', null, null, '', 2, -10),
  (-16, 'Javna 1 (u turi -6)', 'Lepa kt', 'https://www.snow-forecast.com/system/images/36932/large/Crystal-Mountain.jpg?1619614348', 45.232164904903826, 19.794790780707856, -6, 'TourKeyPoint', null, null, '', 1, -9),
  (-17, 'Javna 3 (u turi -6)', 'Najlepsa kt', 'https://wallpapers.com/images/featured/snow-mountain-ydg6x966wun8nkjs.jpg', 45.24628421561786, 19.84560012817383, -6, 'TourKeyPoint', null, null, '', 2, -11),
  (-18, 'Javna 4 (u turi -6)', 'nova javna kt', 'https://cdn.britannica.com/97/158797-050-ABECB32F/North-Cascades-National-Park-Lake-Ann-park.jpg', 45.22383648719875, 19.846165773318674, -6, 'TourKeyPoint', null, null, '', 3, -12),
  (-19, 'Javna 4 (u turi -7)', 'nova javna kt', 'https://cdn.britannica.com/97/158797-050-ABECB32F/North-Cascades-National-Park-Lake-Ann-park.jpg', 45.22383648719875, 19.846165773318674, -7, 'TourKeyPoint', null, null, '', 1, -12),
  (-20, 'Javna 5 (u turi -7)', 'najnovija javna kt', 'https://cdn.britannica.com/95/136995-050-6209F94F/rainforest-Malaysia.jpg', 45.22830260204978, 19.79891452593411, -7, 'TourKeyPoint', null, null, '', 1, -13),
  (-21, 'Javna 2 (u turi -8)', 'Lepsa kt', 'https://plus.unsplash.com/premium_photo-1673859055803-593f6cda5e2b?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fHNub3clMjBtb3VudGFpbnxlbnwwfHwwfHx8MA%3D%3D', 45.24616355261428, 19.820365905761722, -8, 'TourKeyPoint', null, null, '', 1, -10),
  (-22, 'Javna 3 (u turi -8)', 'Najlepsa kt', 'https://wallpapers.com/images/featured/snow-mountain-ydg6x966wun8nkjs.jpg', 45.24628421561786, 19.84560012817383, -8, 'TourKeyPoint', null, null, '', 2, -11),
  (-23, 'Javna 4 (u turi -8)', 'nova javna kt', 'https://cdn.britannica.com/97/158797-050-ABECB32F/North-Cascades-National-Park-Lake-Ann-park.jpg', 45.22383648719875, 19.846165773318674, -8, 'TourKeyPoint', null, null, '', 3, -12),


INSERT INTO tours."TourProblems"(
    "Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved", "Messages", "Deadline")
VALUES 
    (-1, -8, -2, 0, 1, 'Rezervacija nije sacuvana', '2023-11-11 14:00:00'::timestamp, false, '[
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
    ]', '2023-11-29 00:00:00+01'),
    (-2, -6, -2, 2, 2, 'Dodatni troskovi su naplaceni, a nisu bili navedeni prilikom rezervacije. ', '2023-11-13 15:00:00'::timestamp, false, '[
      {
        "SenderId": -3,
          "RecipientId": -6,
        "CreationTime": "2023-11-13T20:03:36.2030688Z",
        "Description": "Dodatni troskovi su sada azurirani i vidljivi prilikom rezervacije. ",
        "IsRead": false
      }
    ]', null),
    (-3, -6, -2, 0, 4, 'Bilo je problema sa organizacijom', '2023-11-15 14:00:00'::timestamp, false, '[]', null),
    (-4, -6, -2, 0, 4, 'Bilo je problema sa organizacijom', '2023-11-03 14:00:00'::timestamp, false, '[]', '2023-11-10 00:00:00+01'),
    (-5, -6, -2, 0, 4, 'Bilo je problema sa organizacijom', '2023-11-13 14:00:00'::timestamp, false, '[]', null);