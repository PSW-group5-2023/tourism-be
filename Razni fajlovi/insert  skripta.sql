INSERT INTO stakeholders."Users"("Id", "Username", "Password", "Role", "IsActive", "ResetPasswordToken", "EmailVerificationToken")
VALUES 
	(-1, 'admin', '8QpgZuFOHE/OKm20yXXM9vkUimZBoJgl7wjfetZxom1u2+xvFsLhQft2lPXSd/A9FvqheUXTFvGYaO3dfBQ8o4D8juFAyXnUb75VpUBHN4U=', 0, true, null, null),
	(-2, 'jane_smith', '8QpgZuFOHE/OKm20yXXM9vkUimZBoJgl7wjfetZxom1u2+xvFsLhQft2lPXSd/A9FvqheUXTFvGYaO3dfBQ8o4D8juFAyXnUb75VpUBHN4U=', 0, true, null, null ),
	(-3, 'author', 'dvX14dynIiSenCwcPYbHo4mEdZGxE+00q0nLvW9hho2fDKKh7lFQum0PyFraSBSDQtDFXn6GTxM7NjeQ3iz+/ppY6oC9qbkr1XgLEMSGWhc=', 1, true, null, null),
	(-4, 'olivia_wilson', 'dvX14dynIiSenCwcPYbHo4mEdZGxE+00q0nLvW9hho2fDKKh7lFQum0PyFraSBSDQtDFXn6GTxM7NjeQ3iz+/ppY6oC9qbkr1XgLEMSGWhc=', 1, true, null, null),
	(-5, 'daniel_taylor', 'dvX14dynIiSenCwcPYbHo4mEdZGxE+00q0nLvW9hho2fDKKh7lFQum0PyFraSBSDQtDFXn6GTxM7NjeQ3iz+/ppY6oC9qbkr1XgLEMSGWhc=', 1, true, null, null),
	(-6, 'tourist', '2Wv1uZyuKahkTYbO9Ar73theUUVRv9YN0Zn+OFgELLV+MrKWVNwdIjsMnxOp/2WzfVrKJiU4KNO+FNT5Vdzqd+3ONW4Ol0kJSDB5phZRrsg=', 2, true, null, null),
	(-7, 'sophia_brown', '2Wv1uZyuKahkTYbO9Ar73theUUVRv9YN0Zn+OFgELLV+MrKWVNwdIjsMnxOp/2WzfVrKJiU4KNO+FNT5Vdzqd+3ONW4Ol0kJSDB5phZRrsg=', 2, false, null, null),
	(-8, 'ethan_clark', '2Wv1uZyuKahkTYbO9Ar73theUUVRv9YN0Zn+OFgELLV+MrKWVNwdIjsMnxOp/2WzfVrKJiU4KNO+FNT5Vdzqd+3ONW4Ol0kJSDB5phZRrsg=', 2, true, null, null),
	(-9, 'ava_young', '2Wv1uZyuKahkTYbO9Ar73theUUVRv9YN0Zn+OFgELLV+MrKWVNwdIjsMnxOp/2WzfVrKJiU4KNO+FNT5Vdzqd+3ONW4Ol0kJSDB5phZRrsg=', 2, false, null, null),
	(-10, 'james_brown', '8QpgZuFOHE/OKm20yXXM9vkUimZBoJgl7wjfetZxom1u2+xvFsLhQft2lPXSd/A9FvqheUXTFvGYaO3dfBQ8o4D8juFAyXnUb75VpUBHN4U=', 0, true, null, null);



INSERT INTO stakeholders."People"("Id", "UserId", "Name", "Surname", "Email", "ProfilePic", "Biography", "Motto")
VALUES 
    (-1, -1, 'Admin', 'Admin', 'john.doe@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Carpe Diem'),
    (-2, -2, 'Jane', 'Smith', 'jane.smith@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'Live in the moment'),
    (-3, -3, 'Author', 'Author', 'author@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 'Stay positive'),
    (-4, -4, 'Olivia', 'Wilson', 'olivia.wilson@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.', 'Spread love'),
    (-5, -5, 'Daniel', 'Taylor', 'daniel.taylor@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'Be yourself'),
	  (-6, -6, 'Tourist', 'Tourist', 'tourist@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.', 'Chase your dreams'),
    (-7, -7, 'Sophia', 'Brown', 'sophia.brown@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.', 'Embrace the journey'),
    (-8, -8, 'Ethan', 'Clark', 'ethan.clark@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'Believe in yourself'),
    (-9, -9, 'Ava', 'Young', 'ava.young@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam.', 'Explore the unknown'),
    (-10, -10, 'James', 'Brown', 'james.brown@example.com', 'https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png', 'Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.', 'Create your own destiny');
    


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
  (-1, 'Tura 1', 'Ova tura je lepa', 0, '{"hike", "bike", "adventure"}', 0, 0, -3, '{-1, -2}', 3.484371, NULL, NULL, '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-2, 'Culinary Delights and Cultural Insights', 'Savor the flavors of a rich tapestry of cultures on our Culinary Delights and Cultural Insights tour. This gastronomic journey will lead you through bustling markets, hidden culinary gems, and renowned restaurants, where you''ll indulge in a diverse range of delectable dishes. But it''s not just about the food – immerse yourself in the local culture through hands-on cooking classes, meet passionate chefs, and explore historical sites that narrate the region''s culinary evolution. Join us for a feast for the senses that goes beyond the plate.', 1, '{"adventure", "old", "culture", "beautiful"}', 1, 100, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-3, 'Tura 3', 'Ova tura je super', 3, '{"forest", "adventure"}', 2, 0, -3, '{-1, -3}', 3.484371,  '2023-11-16 18:33:42.718996+01', '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-4, 'Mystical Adventure in Ancient Ruins', 'Uncover the secrets of the past on our Mystical Adventure in Ancient Ruins tour. Step back in time as you explore the enigmatic remnants of ancient civilizations. Roam through historic ruins, decipher ancient hieroglyphs, and marvel at architectural marvels that have withstood the test of time. Expert archaeologists will guide you through the stories etched in stone, revealing the mysteries of bygone eras. This immersive journey promises a blend of history, archaeology, and awe-inspiring landscapes, making it an unforgettable adventure for history enthusiasts and curious minds alike.', 3, '{"hike"}', 1, 50, -3, '{-1, -3}', 3.484371,  '2023-11-16 18:33:42.718996+01', '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-5, 'Tura za javne 1, 2', 'Ova tura je okej', 1, '{"forest", "nature"}', 1, 40, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-6, 'Enchanting Wilderness Expedition', 'Embark on a journey through nature''s untouched beauty with our Enchanting Wilderness Expedition. This tour takes you deep into the heart of lush forests, serene lakes, and breathtaking landscapes. Traverse scenic trails, witness diverse wildlife, and camp under the starlit sky. Expert guides will share their knowledge of the flora and fauna, ensuring an immersive and educational experience. Disconnect from the hustle and bustle of daily life as you connect with the enchanting wilderness on this rejuvenating adventure.', 3, '{"history", "walking"}', 1, 60, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-7, 'Tura za javne 4, 5', 'Ova tura je okej', 2, '{"forest", "hike", "bike", "adventure"}', 1, 20, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-8, 'Tura za javne 2, 3, 4', 'Ova tura je okej', 0, '{"history", "culture"}', 1, 30, -4, '{-1}', 3.484371, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 2509, "Transportation": 0}]'),
  (-9, 'Belgrade Tour 1', 'Explore Belgrade', 1, '{"forest"}', 1, 25, -3, '{-1}', 5.0, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 3600, "Transportation": 1}]'),
  (-10, 'Kragujevac Tour 1', 'Discover Kragujevac', 2, '{"city", "history"}', 1, 30, -4, '{-1}', 8.5, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 4200, "Transportation": 2}]'),
  (-11, 'Kraljevo Tour 1', 'Explore Kraljevo', 3, '{"city", "museums", "monuments", "culture"}', 1, 35, -3, '{-1}', 7.5, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 3900, "Transportation": 1}]'),
  (-12, 'Vlasenica Tour 1', 'Explore Vlasenica', 1, '{"nature", "adventure", "forest"}', 1, 20, -4, '{-1}', 9.0, NULL, '2023-11-16 18:33:45.459049+01', '[{"TimeInSeconds": 4500, "Transportation": 2}]'),
  (-13, 'Nis Tour 1', 'Discover Nis', 2, '{"city", "history", "monuments"}', 1, 30, -3, '{-1}', 7.8, NULL, '2023-11-16 18:33:42.718996+01', '[{"TimeInSeconds": 4200, "Transportation": 1}]'),
  (-14, 'Belgrade Tour 2', 'Explore Belgrade landmarks', 0, '{"history", "culture"}', 1, 40, -4, '{-1}', 10.0, NULL, '2023-11-16 18:33:42.718996+01', '[{"TimeInSeconds": 4800, "Transportation": 1}]'),
  (-15, 'Belgrade Tour 3', 'Explore Belgrade landmarks', 1, '{"city", "culture"}', 1, 40, -4, '{-1}', 10.0, NULL, '2023-11-16 18:33:42.718996+01', '[{"TimeInSeconds": 4800, "Transportation": 1}]'),
  (-16, 'Belgrade Tour 4', 'Explore Belgrade landmarks', 2, '{"history", "city"}', 1, 40, -4, '{-1}', 10.0, NULL, '2023-11-16 18:33:42.718996+01', '[{"TimeInSeconds": 4800, "Transportation": 1}]'),
  (-17, 'Belgrade Tour 5', 'Explore Belgrade landmarks', 3, '{"history", "adventure"}', 1, 40, -4, '{-1}', 10.0, NULL, '2023-11-16 18:33:42.718996+01', '[{"TimeInSeconds": 4800, "Transportation": 1}]'),
  (-18, 'Belgrade Tour 6', 'Explore Belgrade landmarks', 3, '{"city", "adventure"}', 1, 40, -4, '{-1}', 10.0, NULL, '2023-11-16 18:33:42.718996+01', '[{"TimeInSeconds": 4800, "Transportation": 1}]');

INSERT INTO tours."Preferences"(
	"Id", "UserId", "DifficultyLevel", "WalkingRate", "BicycleRate", "CarRate", "BoatRate", "Tags")
	VALUES 
    (-1, -6, 1, 2, 3, 1, 0, '{"forest", "bike", "hike", "adventure"}'),
    (-2, -8, 3, 0, 1, 2, 3, '{"history", "culture"}');

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
  (-24, 'Belgrade Point 1', 'Start your journey in Belgrade', 'https://a.cdn-hotels.com/gdcs/production156/d901/872376c3-a591-42ad-9efa-ed8779372106.jpg?impolicy=fcrop&w=800&h=533&q=medium', 44.7866, 20.4489, -9, 'TourKeyPoint', null, null, 'Secret Belgrade', 1, null),
  (-25, 'Belgrade Point 2', 'Another interesting spot in Belgrade', 'https://upload.wikimedia.org/wikipedia/commons/5/58/Belgrade._National_Assembly_of_Serbia_building.jpg', 44.8186, 20.4671, -9, 'TourKeyPoint', null, null, 'Secret Belgrade', 2, null),
  (-26, 'Kragujevac Point 1', 'Starting point in Kragujevac', 'https://www.rubiconhotel.com/media/page/oKragujevcu/kragujevac.jpg', 44.0128, 20.9110, -10, 'TourKeyPoint', null, null, 'Secret Kragujevac', 1, null),
  (-27, 'Kragujevac Point 2', 'Historical site in Kragujevac', 'https://kg.ac.rs/slike/aboutkg5.jpg', 44.0165, 20.9126, -10, 'TourKeyPoint', null, null, 'Secret Kragujevac', 2, null),
  (-28, 'Kraljevo Point 1', 'Starting point in Kraljevo', 'https://dynamic-media-cdn.tripadvisor.com/media/photo-o/18/b1/21/7c/vista-do-restaurante.jpg?w=600&h=400&s=1', 43.7250, 20.6892, -11, 'TourKeyPoint', null, null, 'Secret Kraljevo', 1, null),
  (-29, 'Kraljevo Point 2', 'Cultural site in Kraljevo', 'https://staklosrbija.rs/wp-content/uploads/2022/03/narodni-muzej-u-kraljevu-f-1200-833.webp', 43.7241, 20.6881, -11, 'TourKeyPoint', null, null, 'Secret Kraljevo', 2, null),
  (-30, 'Vlasenica Point 1', 'Starting point in Vlasenica', 'https://detektor.ba/wp-content/uploads/2018/02/Vlasenica2-1024x768.jpg', 44.1946, 19.4326, -12, 'TourKeyPoint', null, null, 'Secret Vlasenica', 1, null),
  (-31, 'Vlasenica Point 2', 'Adventure spot in Vlasenica', 'https://cdn.glassrpske.rs/slika/2022/07/750x500/20220708100003_423401.jpg', 44.1922, 19.4501, -12, 'TourKeyPoint', null, null, 'Secret Vlasenica', 2, null),
  (-32, 'Nis Point 1', 'Starting point in Nis', 'https://beogradskisajamturizma.rs/wp-content/uploads/nis_tvrdjava-reka-nisava_1100_2023.jpg', 43.3209, 21.8958, -13, 'TourKeyPoint', null, null, 'Secret Nis', 1, null),
  (-33, 'Nis Point 2', 'Historical site in Nis', 'https://cdn.britannica.com/93/151993-050-D6EF4F79/square-Nis-Serbia.jpg', 43.3195, 21.8969, -13, 'TourKeyPoint', null, null, 'Secret Nis', 2, null),
  (-34, 'Nis Point 3', 'Historical site in Nis', 'https://dynamic-media-cdn.tripadvisor.com/media/photo-o/10/d4/d4/f3/nis-fortress.jpg?w=1200&h=-1&s=1', 43.322321, 21.930270, -13, 'TourKeyPoint', null, null, 'Secret Nis', 3, null),
  (-35, 'Belgrade Point 1', 'Visit historical site in Belgrade', 'https://n1info.rs/wp-content/uploads/2023/01/31/1675178925-Beograd-na-vodi-stanovi-Shutterstock-1.jpg', 44.8220, 20.4502, -14, 'TourKeyPoint', null, null, 'Secret Belgrade', 1, null),
  (-36, 'Belgrade Point 2', 'One more in Belgrade', 'https://www.onlycroatia.com/media/cities/124/4281.jpg', 44.810809, 20.479746, -14, 'TourKeyPoint', null, null, 'Secret Belgrade', 2, null),
  (-37, 'Belgrade Point 3', 'Monument in Belgrade', 'https://www.extracafe.rs/wp-content/uploads/2021/07/kako-je-beograd-dobio-ime.jpg', 44.785478, 20.488494, -14, 'TourKeyPoint', null, null, 'Secret Belgrade', 3, null),
  (-38, 'Belgrade Point 1', 'One more in Belgrade', 'https://www.onlycroatia.com/media/cities/124/4281.jpg', 44.787528, 20.476285, -15, 'TourKeyPoint', null, null, 'Secret Belgrade', 1, null),
  (-39, 'Belgrade Point 2', 'Monument in Belgrade', 'https://www.extracafe.rs/wp-content/uploads/2021/07/kako-je-beograd-dobio-ime.jpg', 44.779923, 20.469455, -15, 'TourKeyPoint', null, null, 'Secret Belgrade', 2, null),
  (-40, 'Belgrade Point 1', 'One more in Belgrade', 'https://www.onlycroatia.com/media/cities/124/4281.jpg', 44.791291, 20.450288, -16, 'TourKeyPoint', null, null, 'Secret Belgrade', 1, null),
  (-41, 'Belgrade Point 2', 'Monument in Belgrade', 'https://www.extracafe.rs/wp-content/uploads/2021/07/kako-je-beograd-dobio-ime.jpg', 44.790347, 20.470520, -16, 'TourKeyPoint', null, null, 'Secret Belgrade', 2, null),
  (-42, 'Belgrade Point 1', 'One more in Belgrade', 'https://www.onlycroatia.com/media/cities/124/4281.jpg', 44.798594, 20.448867, -17, 'TourKeyPoint', null, null, 'Secret Belgrade', 1, null),
  (-43, 'Belgrade Point 2', 'Monument in Belgrade', 'https://www.extracafe.rs/wp-content/uploads/2021/07/kako-je-beograd-dobio-ime.jpg', 44.808277, 20.470254, -17, 'TourKeyPoint', null, null, 'Secret Belgrade', 2, null),
  (-44, 'Belgrade Point 1', 'Visit Belgrade', 'https://www.extracafe.rs/wp-content/uploads/2021/07/kako-je-beograd-dobio-ime.jpg', 44.790347, 20.470520, -18, 'TourKeyPoint', null, null, 'Secret Belgrade', 1, null),
  (-45, 'Belgrade Point 2', 'One more in Belgrade', 'https://www.onlycroatia.com/media/cities/124/4281.jpg', 44.798594, 20.448867, -18, 'TourKeyPoint', null, null, 'Secret Belgrade', 2, null),
  (-46, 'Belgrade Point 3', 'Monument in Belgrade', 'https://www.extracafe.rs/wp-content/uploads/2021/07/kako-je-beograd-dobio-ime.jpg', 44.808277, 20.470254, -18, 'TourKeyPoint', null, null, 'Secret Belgrade', 3, null);


INSERT INTO tours."Equipment"("Id", "Name", "Description")
VALUES
	(-1, 'Voda', 'Količina vode varira od temperature i trajanja ture. Preporuka je da se pije pola litre vode na jedan sat umerena fizičke aktivnosti (npr. hajk u prirodi bez značajnog uspona) po umerenoj vrućini'),
	(-2, 'Štapovi za šetanje', 'Štapovi umanjuju umor nogu, pospešuju aktivnost gornjeg dela tela i pružaju stabilnost na neravnom terenu.'),
	(-3, 'Obična baterijska lampa', 'Baterijska lampa od 200 do 400 lumena.');

INSERT INTO tours."TourProblems"(
    "Id", "TouristId", "TourId", "Category", "Priority", "Description", "Time", "IsSolved", "Messages", "Deadline")
VALUES 
    (-1, -8, -2, 0, 1, 'Rezervacija nije sacuvana', '2023-11-11 14:00:00'::timestamp, false, '[
      {
        "SenderId": -4,
          "RecipientId": -8,
        "CreationTime": "2023-11-11T15:03:36.2030688Z",
        "Description": "Problem u sistemu je u procesu resavanja. Rezervacija ce biti omogucena u narednih nekoliko sati. ",
        "IsRead": false
      },
      {
        "SenderId": -8,
          "RecipientId": -4,
        "CreationTime": "2023-11-11T17:03:36.2030688Z",
        "Description": "Jos uvek nije moguce izvrsiti rezervaciju. ",
        "IsRead": false
      }
    ]', '2023-11-29 00:00:00+01'),
    (-2, -6, -2, 2, 2, 'Dodatni troskovi su naplaceni, a nisu bili navedeni prilikom rezervacije. ', '2023-11-13 15:00:00'::timestamp, false, '[
      {
        "SenderId": -4,
          "RecipientId": -6,
        "CreationTime": "2023-11-13T20:03:36.2030688Z",
        "Description": "Dodatni troskovi su sada azurirani i vidljivi prilikom rezervacije. ",
        "IsRead": false
      }
    ]', null),
    (-3, -6, -2, 0, 4, 'Bilo je problema sa organizacijom', '2023-11-15 14:00:00'::timestamp, false, '[]', null),
    (-4, -6, -2, 0, 4, 'Bilo je problema sa organizacijom', '2023-11-03 14:00:00'::timestamp, false, '[]', '2023-11-10 00:00:00+01'),
    (-5, -6, -2, 0, 4, 'Bilo je problema sa organizacijom', '2023-11-13 14:00:00'::timestamp, false, '[]', null);


INSERT INTO encounters."Challenges"(
    "Id", "CreatorId", "Description", "Name", "Status", "Type", "Latitude", "Longitude", "ExperiencePoints", "KeyPointId", "Image", "LatitudeImage", "LongitudeImage", "Range", "RequiredAttendance")
VALUES (-1, -1, 'Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.', 'Skrivene staze', 1, 0, 45.249055, 19.850548, 190, null, null, null, null, 50, 2),
    (-2, -4, 'Description 2', 'Name 2', 1, 1, 45.252909, 19.855888, 30, null, 'https://fajlovi.bos4.tours/uploads/2020/10/images/tour_217/Petrovaradinska%20tvrdjava%20sat.jpg', 45.253355, 19.861284, 50, null),
    (-3, -1, 'Description 3', 'Name 3', 1, 2, 45.255387, 19.845547, 20, null, null, null, null, 50, null),
    (-4, -1, 'Description 4', 'Name 4', 1, 2, 45.244873, 19.841853, 10, null, null, null, null, 50, null),
    (-5, -1, 'Description 5', 'Name 5', 1, 1, 45.249647, 19.825326, 10, null, 'https://upload.wikimedia.org/wikipedia/commons/c/c1/Serbia-0268_-_Name_of_Mary_Parish_Church_(7344449164).jpg', 45.255128, 19.845097, 50, null),
    (-6, -1, 'Description 6', 'Name 6', 1, 0, 45.264473, 19.825806, 10, null, null, null, null, 50, 2),
    (-7, -4, 'Description 7', 'Name 7', 1, 2, 44.1111, 20.5589, 10, -4, null, null, null, 50, null);


INSERT INTO encounters."ChallengeExecutions"(
	"Id", "TouristId", "ChallengeId", "Latitude", "Longitude", "ActivationTime", "CompletionTime", "IsCompleted")
	VALUES (-1, -8, -1, 45.249058, 19.850543, CURRENT_TIMESTAMP, null, false),
    -- (-2, -9, -1, 0, 0, CURRENT_TIMESTAMP, null, false),
    (-3, -6, -1, 0, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, true);

INSERT INTO encounters."UserExperience"("Id", "UserId", "XP", "Level")
VALUES (-1, -6, 190, 10),
		  (-2, -7, 0, 1),
		  (-3, -8, 50, 3),
		  (-4, -9, 0, 1);

INSERT INTO payments."Bundles"(
	"Id", "Name", "Price", "AuthorId", "ToursId", "BundleState")
	VALUES 
	(-4, 'Bundle 4', '77', -3, '{-3,-4}', 0),
	(-3, 'Bundle 3', '10', -3, '{-4,-3}', 2),
	(-2, 'Bundle 2', '100', -3, '{-1,-3,-4}', 1),
	(-1, 'Bundle 1', '3', -3, '{-1,-4}', 0);

INSERT INTO payments."Wallet"(
	"Id", "UserId", "Balance")
	VALUES (-1, -6, 50);
INSERT INTO payments."Wallet"(
	"Id", "UserId", "Balance")
	VALUES (-2, -7, 40);
INSERT INTO payments."Wallet"(
	"Id", "UserId", "Balance")
	VALUES (-3, -8, 20);
INSERT INTO payments."Wallet"(
	"Id", "UserId", "Balance")
	VALUES (-4, -9, 15);

INSERT INTO tours."EquipmentTrackings"(
    "Id", "TouristId", "NeededEquipment")
VALUES (-1, -6, '{-1, -2}');

INSERT INTO payments."BoughtItems"(
    "Id", "UserId", "TourId", "DateOfBuying", "IsUsed")
VALUES (-1, -9, -4, '2023-12-07 17:06:20.601122+01', true),
       (-2, -6, -4, '2023-12-07 20:56:17.924633+01', true ),
       (-3, -8, -4, '2023-12-07 21:04:17.950647+01', true),
       (-4, -6, -9, '2023-12-25 11:04:17.950647+01', true),
       (-5, -6, -10, '2023-12-20 14:10:17.950647+01', true),
       (-6, -6, -11, '2023-12-22 11:09:17.950647+01', true),
       (-7, -6, -13, '2023-12-02 12:08:17.950647+01', true),
       (-8, -6, -15, '2023-12-11 19:07:17.950647+01', true),
       (-9, -6, -16, '2023-12-25 14:04:17.950647+01', true),
       (-10, -6, -17, '2023-12-25 11:04:17.950647+01', true),
       (-11, -6, -18, '2023-12-25 14:04:17.950647+01', true),
       (-12, -9, -12, '2023-12-26 14:10:17.950647+01', true),
       (-13, -11, -12, '2023-12-26 11:09:17.950647+01', true),
       (-14, -12, -12, '2023-12-26 14:04:17.950647+01', true),
       (-15, -13, -12, '2023-12-26 18:08:17.950647+01', true),
       (-16, -14, -12, '2023-12-26 16:04:17.950647+01', true),
       (-17, -8, -14, '2023-12-25 19:07:17.950647+01', true),
       (-18, -9, -14, '2023-12-25 15:04:17.950647+01', true),
       (-19, -11, -14, '2023-12-25 12:04:17.950647+01', true),
       (-20, -12, -14, '2023-12-25 12:04:17.950647+01', true),
       (-21, -13, -14, '2023-12-25 19:07:17.950647+01', false),
       (-22, -8, -11, '2023-12-22 15:04:17.950647+01', true),
       (-23, -9, -11, '2023-12-22 12:04:17.950647+01', true),
       (-24, -11, -11, '2023-12-22 12:04:17.950647+01', true),
       (-25, -12, -11, '2023-12-22 12:04:17.950647+01', true),
       (-26, -8, -10, '2023-12-20 15:04:17.950647+01', true),
       (-27, -9, -10, '2023-12-20 12:04:17.950647+01', true),
       (-28, -11, -10, '2023-12-20 12:04:17.950647+01', true),
       (-29, -8, -13, '2023-12-02 12:04:17.950647+01', true),
       (-30, -9, -13, '2023-12-02 12:04:17.950647+01', true),
       (-31, -8, -15, '2023-12-11 12:04:17.950647+01', true),
       (-32, -11, -15, '2023-12-11 12:04:17.950647+01', false);

INSERT INTO tours."PositionSimulators"(
	"Id", "Latitude", "Longitude", "TouristId")
VALUES  (-1, 45.257794555848406, 19.845718145370483, -9),
        (-2, 45.25776057083952, 19.84564304351807, -6),
        (-3, 45.25783231694552, 19.84560012817383, -8);

INSERT INTO tours."Sessions"(
    "Id", "TourId", "TouristId", "LocationId", "SessionStatus", "DistanceCrossedPercent", "LastActivity", "CompletedKeyPoints")
VALUES (
    -1,
    -4,
    -9,
    -1,
    2,
    100,
    '2023-12-07 19:25:42.303+01',
    '[{"KeyPointId": -7, "CompletionTime": "2023-12-07T16:06:40.0842597Z"}, {"KeyPointId": -8, "CompletionTime": "2023-12-07T16:07:20.101299Z"}]'
),
(
    -2,
    -4,
    -6,
    -2,
    1,
    100,
    '2023-12-07 20:58:19.478+01',
    '[{"KeyPointId": -7, "CompletionTime": "2023-12-07T19:57:45.0106834Z"}, {"KeyPointId": -8, "CompletionTime": "2023-12-07T19:58:14.9773979Z"}]'
),
(
    -3,
    -4,
    -8,
    -3,
    1,
    100,
    '2023-12-07 21:05:04.672+01',
    '[{"KeyPointId": -7, "CompletionTime": "2023-12-07T20:04:42.0844382Z"}, {"KeyPointId": -8, "CompletionTime": "2023-12-07T20:05:02.0991904Z"}]'
);


INSERT INTO tours."TourRatings"(
    "Id", "PersonId", "TourId", "Mark", "Comment", "DateOfVisit", "DateOfCommenting", "Images")
VALUES (-1, -6, -4, '5', 'Bilo je sjajno, veoma dobro smo se proveli', '2023-10-07 12:34:56', '2023-12-07 12:34:56', ARRAY['https://live.staticflickr.com/7909/47358208621_d866a5513e_b.jpg']),
       (-2, -8, -4, '2', 'Bilo je prilicno lose', '2023-06-07 12:34:56', '2023-11-07 12:34:56', ARRAY['https://hotelzenit.co.rs/wp-content/uploads/2017/06/Katedrala.jpg']),
       (-3, -8, -12, '5', 'Bilo je odlicno!', '2023-12-27 12:34:56', '2023-12-27 19:34:56', ARRAY['https://turizamrs.org/wp-content/uploads/2015/05/Vlasenica-Panorama-1230x790.jpg']),
       (-4, -9, -12, '5', 'Veoma zanimljiva tura.', '2023-12-28 12:34:56', '2023-12-29 12:34:56', ARRAY['https://turizamrs.org/wp-content/uploads/2015/05/Vlasenica-Panorama-1230x790.jpg']),
       (-5, -11, -12, '5', 'Odlicna tura!', '2023-12-27 12:34:56', '2023-12-28 12:34:56', ARRAY['https://turizamrs.org/wp-content/uploads/2015/05/Vlasenica-Panorama-1230x790.jpg']),
       (-6, -12, -12, '4', 'Bilo je dobro.', '2023-12-28 12:34:56', '2023-12-29 12:34:56', ARRAY['https://turizamrs.org/wp-content/uploads/2015/05/Vlasenica-Panorama-1230x790.jpg']),
       (-7, -13, -12, '5', 'Odlicno, super smo se proveli', '2023-12-29 12:34:56', '2023-12-30 12:34:56', ARRAY['https://turizamrs.org/wp-content/uploads/2015/05/Vlasenica-Panorama-1230x790.jpg']),
       (-8, -14, -12, '3', 'Bilo je dosadno', '2023-12-28 12:34:56', '2023-12-28 20:34:56', ARRAY['https://turizamrs.org/wp-content/uploads/2015/05/Vlasenica-Panorama-1230x790.jpg']),
       (-9, -6, -12, '4', 'Bilo je okej', '2023-12-28 12:34:56', '2023-12-28 20:34:56', ARRAY['https://turizamrs.org/wp-content/uploads/2015/05/Vlasenica-Panorama-1230x790.jpg']),
       (-10, -6, -14, '2', 'Bilo je lose', '2023-12-26 12:34:56', '2023-12-27 12:34:56', ARRAY['https://bookaweb.s3.eu-central-1.amazonaws.com/media/73793/beograd-destinacija-feature.jpg']),
       (-11, -8, -14, '5', 'Odlicno!Bez zamerki', '2023-12-26 12:34:56', '2023-12-27 12:34:56', ARRAY['https://bookaweb.s3.eu-central-1.amazonaws.com/media/73793/beograd-destinacija-feature.jpg']),
       (-12, -9, -14, '4', 'Lose organizovano', '2023-12-26 12:34:56', '2023-12-27 12:34:56', ARRAY['https://bookaweb.s3.eu-central-1.amazonaws.com/media/73793/beograd-destinacija-feature.jpg']),
       (-13, -11, -14, '5', 'Bilo je odlicno', '2023-12-26 12:34:56', '2023-12-28 12:34:56', ARRAY['https://bookaweb.s3.eu-central-1.amazonaws.com/media/73793/beograd-destinacija-feature.jpg']),
       (-14, -12, -14, '5', 'Zanimljiva tura', '2023-12-26 12:34:56', '2023-12-27 12:34:56', ARRAY['https://bookaweb.s3.eu-central-1.amazonaws.com/media/73793/beograd-destinacija-feature.jpg']),      
       (-15, -8, -11, '5', 'Bilo je sjajno', '2023-12-23 12:34:56', '2023-12-24 12:34:56', ARRAY['https://www.kraljevoturizam.rs/img/slika.jpg']),
       (-16, -9, -11, '4', 'Bilo je dobro', '2023-12-23 12:34:56', '2023-12-24 12:34:56', ARRAY['https://www.kraljevoturizam.rs/img/slika.jpg']),
       (-17, -11, -11, '5', 'Odlicna organizacija', '2023-12-23 12:34:56', '2023-12-24 12:34:56', ARRAY['https://www.kraljevoturizam.rs/img/slika.jpg']),
       (-18, -12, -11, '5', 'Veoma zanimljiva tura', '2023-12-23 12:34:56', '2023-12-24 12:34:56', ARRAY['https://www.kraljevoturizam.rs/img/slika.jpg']),       
       (-19, -8, -10, '2', 'Bilo je prilicmo lose', '2023-12-23 12:34:56', '2023-12-25 12:34:56', ARRAY['https://hotelzenit.co.rs/wp-content/uploads/2017/06/Katedrala.jpg']),
       (-20, -9, -10, '3', 'Jako dosadno, bilo je zanimljivo', '2023-12-23 12:34:56', '2023-12-25 12:34:56', ARRAY['https://hotelzenit.co.rs/wp-content/uploads/2017/06/Katedrala.jpg']),
       (-21, -11, -10, '1', 'Bilo je uzasno', '2023-12-23 12:34:56', '2023-12-25 12:34:56', ARRAY['https://hotelzenit.co.rs/wp-content/uploads/2017/06/Katedrala.jpg']),
       (-22, -8, -13, '5', 'Odlicno!Bez zamerki', '2023-12-26 12:34:56', '2023-12-27 12:34:56', ARRAY['https://bookaweb.s3.eu-central-1.amazonaws.com/media/73793/beograd-destinacija-feature.jpg']),
       (-23, -9, -13, '4', 'Lose organizovano', '2023-12-26 12:34:56', '2023-12-27 12:34:56', ARRAY['https://bookaweb.s3.eu-central-1.amazonaws.com/media/73793/beograd-destinacija-feature.jpg']),
       (-24, -8, -15, '5', 'Bilo je odlicno', '2023-12-26 12:34:56', '2023-12-28 12:34:56', ARRAY['https://bookaweb.s3.eu-central-1.amazonaws.com/media/73793/beograd-destinacija-feature.jpg']);

INSERT INTO stakeholders."UserNews" (
    "Id", "TouristId", "LastSendMs", "SendingPeriod")
VALUES (-1, -6, 0, 0),
       (-2, -7, 0, 0),
       (-3, -8, 0, 0),
       (-4, -9, 0, 0);
