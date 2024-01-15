INSERT INTO stakeholders."Users"(
	"Id", "Username", "Password", "Role", "IsActive", "ResetPasswordToken", "EmailVerificationToken")
	VALUES 
    (-5, 'stefanstojanovic', 'dvX14dynIiSenCwcPYbHo4mEdZGxE+00q0nLvW9hho2fDKKh7lFQum0PyFraSBSDQtDFXn6GTxM7NjeQ3iz+/ppY6oC9qbkr1XgLEMSGWhc=', 1, true, NULL, NULL),
    (-4, 'ivanapopovic', 'dvX14dynIiSenCwcPYbHo4mEdZGxE+00q0nLvW9hho2fDKKh7lFQum0PyFraSBSDQtDFXn6GTxM7NjeQ3iz+/ppY6oC9qbkr1XgLEMSGWhc=', 1, true, NULL, NULL),
    (-3, 'nikoladjordjevic', 'dvX14dynIiSenCwcPYbHo4mEdZGxE+00q0nLvW9hho2fDKKh7lFQum0PyFraSBSDQtDFXn6GTxM7NjeQ3iz+/ppY6oC9qbkr1XgLEMSGWhc=', 1, true, NULL, NULL),
    (-2, 'jovananikolic', '8QpgZuFOHE/OKm20yXXM9vkUimZBoJgl7wjfetZxom1u2+xvFsLhQft2lPXSd/A9FvqheUXTFvGYaO3dfBQ8o4D8juFAyXnUb75VpUBHN4U=', 0, true, NULL, NULL),
    (-1, 'markopetrovic', '8QpgZuFOHE/OKm20yXXM9vkUimZBoJgl7wjfetZxom1u2+xvFsLhQft2lPXSd/A9FvqheUXTFvGYaO3dfBQ8o4D8juFAyXnUb75VpUBHN4U=', 0, true, NULL, NULL),
    (-6, 'anaivanovic', 'dvhRNsTWf+OgU/Kbdt/MRvVWBZ+s/BNqsmSH9AurBMTj9m4cml9kG/2XGCMrP4UarMOtmecjiF+q7fDjvitcOs0sBUt4oPSwLUQTZBkV3x8=', 2, true, NULL, NULL),
    (-7, 'lukastankovic', 'MvhubNOwmmqs4dE1e9VAR64KAUk2To3031RLyWwWNmvW6lnPOt36AlIIXw0qpqJlVLNdf0WU0dDY5LWunMK27UM08/Q7XGJbbY18ql8PQHk=', 2, true, NULL, NULL),
    (-8, 'katarinastojkovic', '7IOHpM31bKnANVn4rRWAwcUK1Mx0+6h6RsZBgTrbWkwyLUAu2h+K5XcvWNAmpBQlJyaHF3ujEXeYFD/at62aPvuD/DY4ahTeXkRc6/JUrRo=', 2, true, NULL, NULL),
    (-9, 'stefanstevanovic', 'YxjTD1azpTiMHdDSz0BmOQgGq24nB6hga25xl+7ry/zhc7PwQMJmyuP/jnbmv4tfMoiHu6AvtAguyyLu+KDV10cmls0817zlw9Z7itaZXec=', 2, true, NULL, NULL),
    (-10, 'momcilojovanovic', 'kehmRK2p6VOc6R1VfPEZQv5nYGbvsEiojFniQvtWyV+eqO/i9cQX/B8AP4m5/qE2Yvfa9nUGWpCmblvPCU1pS7z8XeK8yumoAAflxpEcp6g=', 2, true, NULL, NULL);

INSERT INTO stakeholders."People"(
	"Id", "UserId", "Name", "Surname", "Email", "ProfilePic", "Biography", "Motto", "Latitude", "Longitude")
	VALUES 
    (-5, -5, 'Stefan', 'Stojanovic', 'daniel.taylor@example.com', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRwFPvxRehntR5397hV7BnIqzYiRwXuS-dEA&usqp=CAU', 'I, Stefan Stojanović, navigate the complexities of life with a harmonious blend of analytical acumen and a creative spirit. My insatiable curiosity drives me to unravel the intricacies of the world, crafting a narrative that seamlessly intertwines logic and imaginative expression.', 'Be yourself', NULL, NULL),
    (-4, -4, 'Ivana', 'Popovic', 'olivia.wilson@example.com', 'https://i.pinimg.com/736x/6c/74/0a/6c740ab80717f5d41deab06d8040b1f0.jpg', 'I explore the world through the lens of art and science, seamlessly weaving imaginative concepts with profound analytical thinking. My passionately dedicated pursuit of storytelling and unraveling the essence of reality defines me as a true explorer fearlessly venturing into new horizons, harmonizing rationality and creativity.', 'Spread love', NULL, NULL),
    (-3, -3, 'Nikola', 'Djordjevic', 'author@example.com', 'https://images.unsplash.com/photo-1628563694622-5a76957fd09c?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW5zdGFncmFtJTIwcHJvZmlsZXxlbnwwfHwwfHx8MA%3D%3D', 'I am a visionary mind, seamlessly blending analytical prowess with artistic expression. My unique ability to weave complex ideas into compelling narratives transforms the mundane into the extraordinary, defining me as a trailblazer at the intersection of logic and creativity.', 'Stay positive', NULL, NULL),
    (-2, -2, 'Jovana', 'Nikolic', 'jane.smith@example.com', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS4DQ-tp12zlDGEUfulC2NNYwJ7vvskGXip6w&usqp=CAU', 'Jovana Nikolic is an enigmatic individual, known for her unparalleled creativity in merging art and technology. With a keen intellect and a passion for innovation, she navigates a surreal world of imagination, leaving a trail of wonder and inspiration in her wake.', 'Live in the moment', NULL, NULL),
    (-1, -1, 'Marko', 'Petrovic', 'john.doe@example.com', 'https://play-lh.googleusercontent.com/C9CAt9tZr8SSi4zKCxhQc9v4I6AOTqRmnLchsu1wVDQL0gsQ3fmbCVgQmOVM1zPru8UH=w240-h480-rw', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Carpe Diem', NULL, NULL),
    (-6, -6, 'ana', 'ivanovic', 'ivanovicana628@gmail.com', 'https://i.pinimg.com/550x/1f/83/c5/1f83c5ce9090c12d1969ad7a3745cc82.jpg', 'I, Ana Ivanović, traverse lifes path with a graceful harmony of strategic insight and artistic finesse. Fueled by an unwavering curiosity, I unravel the intricacies of the world, crafting a narrative that seamlessly intertwines logic with the elegance of imaginative expression.', 'Believe in yourself', NULL, NULL),
    (-7, -7, 'Luka', 'Stankovic', 'leopoldinapraksa@gmail.com', 'https://e0.pxfuel.com/wallpapers/932/376/desktop-wallpaper-stylish-boys-cool-d-profile-pics-for-facebook-whatsapp-pretty-boys.jpg', 'I, Luka Stanković, embark on the journey of life with a unique fusion of analytical insight and artistic flair. My ceaseless curiosity propels me to decipher the nuances of the world, constructing a narrative that seamlessly intertwines logic with creative expression.', 'Chase your dreams', NULL, NULL),
    (-8, -8, 'Katarina', 'Stojkovic', 'leopoldinica123@gmail.com', 'https://newprofilepic.photo-cdn.net//assets/images/article/profile.jpg?90af0c8', 'I, Katarina Stojković, navigate lifes tapestry with a captivating blend of analytical precision and a creative heartbeat. Fueled by an insatiable curiosity, I unravel the threads of the world, crafting a narrative that seamlessly intertwines logic with the poetry of imagination.', 'Embrace the journey', NULL, NULL),
    (-9, -9, 'Stefan', 'Stevanovic', 'leopoldina.djanic01@gmail.com', 'https://media.vanityfair.com/photos/63068cbbbfb0c00da24590fe/master/pass/Luke-MacFarlane-Profile-Story-Image.jpg', 'I, Stefan Stevanović, embark on lifes odyssey with a unique fusion of analytical prowess and a creative spirit. Driven by an unyielding curiosity, I unravel the intricacies of the world, crafting a narrative that seamlessly intertwines logic with imaginative expression.', 'Explore the unknown', NULL, NULL),
    (-10, -10, 'Momcilo', 'Jovanovic', 'momciloj110@gmail.com', 'https://imgv3.fotor.com/images/gallery/Realistic-Male-Profile-Picture.jpg', 'I, Momčilo Jovanović, navigate the realms of existence with a distinctive blend of analyticalinsight and a creative heartbeat. Fueled by an unquenchable curiosity, I unravel the complexities of the world, weaving a narrative that seamlessly merges logic with the artistry of imagination.', 'Create your own destiny', NULL, NULL);

INSERT INTO stakeholders."UserNews"(
	"Id", "TouristId", "LastSendMs", "SendingPeriod")
	VALUES 
    (-3, -6, 0, 0),
    (-4, -7, 0, 0),
    (-5, -8, 0, 0),
    (-6, -9, 0, 0),
    (-7, -10, 0, 0);

INSERT INTO payments."Wallet"(
	"Id", "UserId", "Balance")
	VALUES 
    (-3, -6, 0),
    (-4, -7, 0),
    (-5, -8, 0),
    (-6, -9, 0),
    (-7, -10, 0);

INSERT INTO encounters."UserExperience"(
	"Id", "UserId", "XP", "Level")
	VALUES 
    (-3, -6, 0, 1),
    (-4, -7, 0, 1),
    (-5, -8, 0, 1),
    (-6, -9, 0, 1),
    (-7, -10, 0, 1);

INSERT INTO stakeholders."Followers"(
	"Id", "FollowerId", "FollowedId", "Notification")
	VALUES 
    (-1, -3, -4, '{"Read": false, "Content": "Nikola Djordjevic has started following you", "TimeOfArrival": "2024-01-15T13:46:19.305Z"}'),
    (-3, -7, -5, '{"Read": false, "Content": "Luka Stankovic has started following you", "TimeOfArrival": "2024-01-15T13:48:57.663Z"}'),
    (-4, -8, -5, '{"Read": false, "Content": "Katarina Stojkovic has started following you", "TimeOfArrival": "2024-01-15T13:50:24.789Z"}'),
    (-5, -9, -4, '{"Read": false, "Content": "Stefan Stevanovic has started following you", "TimeOfArrival": "2024-01-15T13:51:52.818Z"}'),
    (-6, -6, -4, '{"Read": false, "Content": "ana ivanovic has started following you", "TimeOfArrival": "2024-01-15T13:52:52.96Z"}'),
    (-7, -6, -3, '{"Read": false, "Content": "ana ivanovic has started following you", "TimeOfArrival": "2024-01-15T13:53:11.833Z"}'),
    (-8, -6, -5, '{"Read": false, "Content": "ana ivanovic has started following you", "TimeOfArrival": "2024-01-15T13:54:35.032Z"}'),
    (-9, -5, -3, '{"Read": false, "Content": "Stefan Stojanovic has started following you", "TimeOfArrival": "2024-01-15T13:56:21.417Z"}');

INSERT INTO blog."Blogs"(
    "Id", "Title", "Description", "CreationDate", "Status", "UserId", "RatingSum", "Ratings")
VALUES (
    -1,
    'Unveiling the Mystical Marvels: A Whimsical Expedition through Enchanted Lands',
    '## Introduction

Embark on a journey like never before as we delve into the heart of mystical landscapes and unearth the secrets hidden within. Our expedition promises a fusion of awe-inspiring scenery, cultural wonders, and a touch of magic that will leave you spellbound. Join us on this extraordinary adventure as we navigate through the ethereal realms of wonder.

---

##  The Portal Opens

The expedition kicks off with a magical portal awaiting your arrival. ! Step through and leave the ordinary world behind as you enter a realm where reality blends seamlessly with fantasy. 

---

## Enchanting Landscapes

Our first stop takes us through breathtaking landscapes straight out of a fairy tale. From rolling hills adorned with vibrant wildflowers to majestic waterfalls that seem to defy gravity, each step unravels the natural beauty that defines these enchanted lands. ![Landscapes](https://www.explore.com/img/gallery/the-50-most-incredible-landscapes-in-the-whole-entire-world/intro-1672072042.jpg)

---

##  Whispers of Ancient Wisdom

Amidst the captivating scenery, we encounter wise elders and mystics who hold the keys to ancient knowledge. Their tales, passed down through generations, reveal the rich history and wisdom that permeate the very essence of these magical realms. !

---

##  Cultural Kaleidoscope

Immerse yourself in the vibrant cultures that thrive in these mystical lands. From lively festivals celebrating celestial unions to traditional dances that echo through the valleys, every moment is a celebration of life, love, and the extraordinary. ![Cultural Festival](https://triangleonthecheap.com/wordpress/wp-content/uploads/2017/10/american-indian-heritage-celebration-2.jpg)

---

##  Creatures of Fantasy

No mystical expedition is complete without encountering fantastical creatures. From graceful unicorns that prance through moonlit meadows to mischievous sprites playing hide-and-seek in the shadows, each encounter is a testament to the magical biodiversity that thrives in this realm. !

---

## The Celestial Symphony

As the expedition unfolds, witness the celestial symphony that graces these enchanted lands. Starlit skies come alive with dancing constellations, and the moon weaves tales of its own. Its a spectacle that transcends imagination and leaves a lasting imprint on the soul. !

---

Our whimsical expedition through these enchanted lands has come to an end, but the memories will linger forever. The magic weve experienced is not confined to the realms we visited but resonates within us, inviting us to carry a piece of the extraordinary in our hearts as we return to the ordinary.

Dare to dream, for in the world of enchantment, dreams are the threads that weave the fabric of reality. Until the next adventure, may your days be touched by the mystical marvels weve uncovered together.',
    '2024-01-15 13:42:33.109316+01',
    1,
    -3,
    0,
    '[]'
);

INSERT INTO blog."Blogs"(
    "Id", "Title", "Description", "CreationDate", "Status", "UserId", "RatingSum", "Ratings")
VALUES (
    -2,
    'Exploring the Hidden Treasures: A Journey through Novi Sad and Fruska Gora',
    '## Introduction

Buckle up for an immersive adventure as we navigate the charming city of Novi Sad and traverse the picturesque landscapes of Fruska Gora. This journey promises a delightful blend of cultural richness, historical marvels, and the serene beauty of nature. Join us as we unveil the hidden treasures woven into the tapestry of this enchanting region.

---

## Novi Sad - Gateway to the North

Our journey begins in the heart of Vojvodina, Serbia, with the vibrant city of Novi Sad. Nestled along the banks of the Danube River, Novi Sad welcomes us with its baroque architecture, lively atmosphere, and a tapestry of cultures that have shaped its identity over the centuries.

---

## Petrovaradin Fortress - A Timeless Citadel

Dominating the Danubes skyline, Petrovaradin Fortress stands as a testament to Novi Sads rich history. Explore the labyrinthine tunnels, walk the historic ramparts, and absorb the panoramic views of the city below. The fortress is a living relic that whispers tales of bygone eras.

![Petrovaradin Fortress](https://media.tacdn.com/media/attractions-splice-spp-674x446/0b/39/ad/cc.jpg)

---

## The Danube Promenade

Stroll along the enchanting Danube promenade, where the rivers gentle current mirrors the tranquility of the city. Admire the elegant architecture lining the waterfront, indulge in local delicacies at riverside cafes, and feel the pulse of Novi Sads vibrant energy.

![Danube Promenade](https://media.istockphoto.com/id/1217963688/photo/novi-sad.jpg?s=612x612&w=0&k=20&c=cA8ZIsB-9k0XkMcQ5LlSynIxpmIKaJS3WWLge3tYaTY=)

---

## Fruska Gora - Natures Sanctuary

Leaving the city behind, our journey takes us to the serene haven of Fruska Gora National Park. Lush greenery, diverse flora, and fauna, and ancient monasteries dotting the landscape characterize this nature lovers paradise.

![Vidikovac](https://static.wixstatic.com/media/f0dcb1_9522cdb646684aca8badecf55d32615b~mv2.jpg/v1/fill/w_736,h_500,al_c,q_85/f0dcb1_9522cdb646684aca8badecf55d32615b~mv2.jpg)

---

## Monastic Marvels

Explore the hidden gems of Fruska Gora – its monasteries. Dating back to medieval times, these monastic complexes offer a glimpse into the regions spiritual and cultural heritage. Wander through peaceful courtyards and marvel at centuries-old frescoes that adorn the chapel walls.

---

## Wine Tasting in Fruska Gora

No journey through this region is complete without savoring its wines. Fruska Gora is renowned for its vineyards, and a wine tasting experience amidst the rolling hills provides a perfect finale to our adventure. Indulge in local varieties while soaking in the panoramic views of the vine-covered landscapes.

---

# Conclusion

As our exploration through Novi Sad and Fruska Gora comes to an end, the memories of this enchanting journey will linger. From the cultural richness of Novi Sad to the serene beauty of Fruska Gora, every moment is a celebration of the regions diverse tapestry.

May this journey inspire you to explore the hidden treasures within your own surroundings, for in every corner, there lies a story waiting to be told. Until the next adventure, embrace the beauty that surrounds you and let the spirit of exploration guide your path. Safe travels!',
    '2024-01-15 14:54:06.128961+01',
    4,
    -3,
    0,
    '[]'
);

INSERT INTO blog."Blogs"(
    "Id", "Title", "Description", "CreationDate", "Status", "UserId", "RatingSum", "Ratings")
VALUES (
    -3,
    'Discovering the Wonders: A Quest through Mythical Realms',
    '## Introduction\n\nEmbark on a mythical journey as we delve into the enchanting realms of magic and wonder. This quest promises to unveil the hidden mysteries, mythical creatures, and ethereal landscapes that exist beyond the boundaries of the ordinary. Join us on this magical adventure and let your imagination soar!\n\n---\n\n## The Portal of Legends\n\nOur quest begins at the mystical Portal of Legends, a gateway to realms unknown. Step through its shimmering veil and leave the mundane world behind as you enter a dimension where myths come to life.\n\n---\n\n## Mystical Creatures\n\nEncounter majestic creatures that inhabit these mythical realms. From wise dragons guarding ancient treasures to playful phoenixes soaring through the skies, every encounter is a testament to the magical biodiversity that thrives in this enchanted world.\n\n---\n\n## Ethereal Landscapes\n\nJourney through breathtaking landscapes that defy the laws of nature. Floating islands adorned with vibrant flora, cascading waterfalls that flow upwards, and forests where the trees whisper ancient secrets—all contribute to the otherworldly beauty of these realms.\n\n---\n\n## Tales of Old\n\nAmidst the magical landscapes, listen to tales of old from wise sages and ancient storytellers. These stories, passed down through generations, carry the wisdom of the mythical realms, revealing the intricate tapestry of their history and legends.\n\n---\n\n## Celestial Phenomena\n\nWitness celestial phenomena that paint the skies with hues unseen in the mortal world. From shimmering auroras that dance with the stars to moonlit festivals hosted by celestial beings, the wonders of the night sky are a spectacle to behold.\n\n---\n\n## The Quests End\n\nAs our quest through mythical realms comes to an end, the memories of magical encounters and fantastical landscapes will forever linger. Though we return to the realm of the ordinary, the spark of magic within us remains, inviting us to believe in the extraordinary.\n\nDare to dream, for in the world of myth and magic, dreams are the threads that weave the fabric of reality. Until the next quest, may your days be touched by the wonders weve discovered together.',
    '2024-01-15 15:30:45.789012+01',
    1,
    0,
    0,
    '[]'
);

INSERT INTO blog."Blogs"(
    "Id", "Title", "Description", "CreationDate", "Status", "UserId", "RatingSum", "Ratings")
VALUES (
  -4,
  'Exploring Palić: A Lakeside Retreat',
  '## Introduction

Welcome to Palić, a hidden gem nestled in the northern part of Serbia. This quaint town, wrapped around the serene Palić Lake, offers a perfect escape for those seeking tranquility and natural beauty. Join us as we embark on a journey through the charming streets, lush parks, and the enchanting lakefront of Palić.

---

## Lakeside Tranquility

Our journey begins with the picturesque Palić Lake, a shimmering oasis surrounded by lush greenery. Take a leisurely stroll along the lakeside promenade, breathe in the fresh air, and let the soothing sounds of nature create a sense of serenity.

![Palić Lake](data:image/jpeg;base64,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)

---

## Art Nouveau Architecture

Explore the rich history and architectural beauty of Palić as you wander through the towns streets. Marvel at the well-preserved Art Nouveau buildings that showcase the towns elegant charm and offer a glimpse into its cultural heritage.

![Art Nouveau Architecture](https://www.suboticasinagoga.rs/sites/default/files/inline-images/23.jpg)

---

## Palić Park - Natures Haven

Step into Palić Park, a verdant oasis that complements the towns beauty. Stroll through tree-lined pathways, discover hidden alcoves, and bask in the beauty of colorful flowerbeds. The park provides a perfect setting for a leisurely afternoon.

![Palić Park](https://sobeiapartmani.com/wp-content/uploads/2022/01/palic1a.jpg)

---

## Grand Terrace - A Culinary Journey

Indulge your taste buds at the iconic Grand Terrace, overlooking Palić Lake. Enjoy a culinary journey with a blend of traditional Serbian flavors and international cuisine. The picturesque view enhances the dining experience, creating memories that linger.

![Grand Terrace](https://dynamic-media-cdn.tripadvisor.com/media/photo-o/09/61/f7/7a/park-heroja.jpg?w=500&h=400&s=1)

---

## Thermal Springs and Wellness

Palić is renowned for its thermal springs that have been attracting visitors for centuries. Immerse yourself in the rejuvenating waters of the Palić Thermal Springs or pamper yourself with spa treatments, embracing the towns wellness offerings.


---

## Chapter 6: Sunset Serenade

As the day winds down, witness the enchanting sunset over Palić Lake. Find a quiet spot along the shore, watch the sky transform into a canvas of warm colors, and let the tranquil beauty of Palić leave an everlasting impression.

![Sunset at Palić Lake](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRpvsmNtR4OWc_mcFwHncWbzeg_A4Hh8laxGTwLFAyHyLZ2Q3JuSSMwRbhdaN_Tby4RCKM&usqp=CAU)

---

# Conclusion

Our exploration of Palić concludes, leaving behind memories of lakeside tranquility, architectural elegance, and culinary delights. Palić, with its timeless charm, invites you to embrace the slow pace of life and connect with nature.

May this glimpse into Palić inspire you to embark on your own adventure and discover the hidden treasures of this lakeside retreat. Until the next journey, may your travels be filled with serenity and the joy of discovery. Safe travels!',
'2024-01-15 14:52:15.171213+01',
4,
-4,
0,
'[]'
);

INSERT INTO blog."Blogs"(
    "Id", "Title", "Description", "CreationDate", "Status", "UserId", "RatingSum", "Ratings")
VALUES (
  -5,
  'Đerdap: Exploring the Danubes Majestic Gorge',
  '## Introduction

Welcome to Đerdap, a natural wonder where the mighty Danube River cuts through the Carpathian Mountains, creating a breathtaking gorge. Join us on a journey through history, stunning landscapes, and the enchanting allure of one of Europes most captivating regions.

---

## The Gates of Iron

Đerdap, often referred to as the "Iron Gates," is a striking gorge where the Danube River winds its way through sheer cliffs. Witness the mesmerizing spectacle of the river slicing through the Carpathians, creating a gateway of unparalleled natural beauty.


---

## Lush Danube National Park

Explore the lush beauty of the Đerdap National Park that surrounds the gorge. Dense forests, diverse flora, and fauna, along with numerous hiking trails, offer a haven for nature enthusiasts. Take in the panoramic views and immerse yourself in the tranquility of this natural oasis.

![Danube National Park](data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBYWFRgWFhYZGBgaGhocHBwYGhgeGhodGhoaGhwcHBweIS4lHB4rHxoaJjgmKy8xNTU1GiQ7QDs0Py40NTEBDAwMEA8QHhISHjQrJCs0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NP/AABEIAMsA+QMBIgACEQEDEQH/xAAbAAACAwEBAQAAAAAAAAAAAAACAwEEBQYAB//EAD4QAAEDAgQDBQYFAwQBBQEAAAEAAhEhMQMEEkFRYXEFIoGRoQYTMrHR8EJSweHxFBWSB2JyoiMzVGOCshb/xAAZAQADAQEBAAAAAAAAAAAAAAAAAQIDBAX/xAAjEQACAgEFAQEAAwEAAAAAAAAAAQIREgMTITFBUWEEcZEy/9oADAMBAAIRAxEAPwDJ0KSxMLUQC9o8oSGKdKbC9CYrFhqMMRQiagR5jFbfmA1mlog7njwXi9hbuH8ePVViEu+yugHmUOlNcwqITAANU6UYaiDUgF6UQYmAKYSYAhiJrUQaihSxgaVIajARNYgYAamtYpaxGGpACGow1E1qNrUDBa1SGogEQCQAhqMM3XoTGpAC1iY1q81qcxiQyWMThhIGojVJgMe8AUgqtrKcGodJUAchCkNTdKkMXWZidK8Gp2le0pkitK9pTdK9pQAoBSAm6FIYgCGBG5g2XtCJlEigDhqNKsqGMmiQCA1TpTzhwVJe6vO/NJsBMKQEelGGJAA1iMNTGsRtYgYoBGGpgYmMbCQxACMBN0KQxACwEYYpDUaQAtYiDUYaja1SALGJinSvBqBktCOVAamYbJUsZLGoac/RP93xICXob+YKbHRyZZzUtYntwnCy1sLKsABcATvH0W8pqJEYuRj4eAXGGtJPACSrH9rxPyO8pXTBxADhaIHIK3l8UzSq5pfyn4jZaC9ZxYyh1adwYM0jzQY+X0mPELr/AGiyQeGPaDrtT8Q5nkqmF2KyB7wu1HcG3Lh/K0j/ACI0myZaDukcxoXtK6fH7BY2O9La1sfHisl/Zj66RrA3bVax1oy6ZnLSlEztK8GrQ/tz9IdoJDrEV84t4q4fZ7G2a11rObvtUiqb1IrtoShJ9IxQxEwQtT+0Y0F2h0NmbSIvSZKrsYCjOL6YsWuxAAK9oTHYSlkhACxhojhkJ4eSme6SsZVaxMDU04cKQxFiF6VIanjCN4ovBiVgKDE/AeW23oeY4Im4aIYal8jTEaF4MVjQpDEWAlrE0MTNCkBKxmh2PksNwJebGA2QJ53qr2Y7OwdJ0jTWhEn9bSsbBwnTIExfh4p+azOuzQ3jG6wlGTlaZvGUVGmim/DIJbuDCNmGenVeaxGMNamRAAB4n0/dL1felqsMwlPuVPBSs5fBxXWlWsDMd7vU5i4SzhD+UPu+a2kkyFJo2mdoABzSQ4RQiwPOUvJ9o94NE33i3VZTDG0pmE6shqxeiqNFqs6bHDz3qQBO9+Cbg5oOiRBI6rGb2nSC2esj5IP6/SAWNLTvw8Fjsy+G27H6b+ce0MNwDRIyBNoDSKW4LMZ2y4xqAp4K7h51kSCByn0UuEoqmilOL5s87NjUWlxaRsE1/aAaKCSb0Wfnn4RfqBqRbceSfl80HAhrNRihP6p4OroWSurNPs/tAEy7dNGVw7aR8WqDaTustjcV0hrGM03rPkFQzONjAw5xEcLcrIjptvhilqJLlGj22cNzCABrERHxdOYXOBqtYmpxlxk/ReGGuqCxVWcs3k7oUxiNjCrDG81oZfBYR8IPiR+qcp0CjZlBicxrBefRW8zhss0aTzJ/hA3JuNYU5JoHFphMzLR+GeqRiOkmBCacuRcQmHBe2HMYS6Zkg0jgOM/JTaXI0nLgZhdkYjgDAgiZJFOqeexXiKtI3IJp6KcvhYzu8XkRcGnhVWcfMAAMYXOdM0rJIWW5Nvg324JcmbmskWGC5p6H9EGDgOcYDSTyTzl3n8JpeQZra61MlisYNLu6QBINCTfa6pzaX1magnLnhGRmMk5nxCh3SYWznMyx7TMzPdHDmfVVcQsLYDIIsbeaIzbXKHKCT4ZVLyRE0Gy81hOyNrFcZksQ7QOZHyVOSRKi2UWsTGiFrs7Lbu4k7xH0XsXsxpjSdPWs87rPdiabMjLLkGpXn5QMGp5bpF7yegokf1uDwf5D6ozQYM+BZftzFZGjFfQAEPJIFvwukRMhb2T9syKYrAdpZQ7bGh9FyGsg9+K716wfXp0RMbO/IjgeMHeI9VlGco9Mtwi+0fSMt7S5Z4HfLJ/O0j1Ej1Wvl8Vj/gex3/F7T8ivjrQZezaSaSa1qJ+6r2C2KwJil6xXwstlrS9IejHw+1OwXbypZI2ovin9XiNu51QI7ztrdVA7QeaF7z1c6I4RNirWrfYtj9PubHN3bHRGWYZuCF8Owu0MQUZiYjRJ+F7xQVihqrWV9oszhmGY74Bs4hw8NYMIyDbZ9qGVwzZwCFmVeD3HDqDdfOOz/b/EAjEwmvr8TCWnyqJjour7K9qMrjkNa/Q82a8aSTwB+EnoUr/ROLXn+HRHExWVJvvxSjnHn4q/NFoNpKj3aFXwlt+MBr6Rpb1Ir5q45pffQaRcfcpbMIG5g+ia3LtBEumeFIQ5IcUwP7e+KD1CB2WcLgjwVz3YB7ry3rUeaeHvAuHdCp3GVtpmU1h4p7GOm8nhJWkx0gksr4IG47QfgjaiTm34PbS9IY0BvfBEmhm3n4earva8mjiRyJWg1+phBBAmndmAfmquHlSZja4sR4KYy+lOPVHsDBYPjLp5W6qDmNNGi28QSJ3r9wjy8a3MdSI4z+3qn4mTbEtdq8j8rItXyGLq0A7tJ5EUqOarNqZcSfFWsqGyQWgmJE/yrWEDJa0Naf8AsPAioRko9IMZS7ZWDQRDcMnnBSxlXflPkVecXH8TiRcCAflXovHOaQQ4wYnvEAQkpPwpwXonL4D5i0WBmKq5qePwzHMD+Vk5j2nyzGy/FYKxIM+gqRzXP5r/AFMyzB3T70g/gDmiIvLm2nh8qqXbfQ4pJcM7L+u4tI8YS39oSXNAAA3JF/NfK85/qZjuc73WCxjTqgua5zxSlQ7TqBrSiwc37T5l8OOOWQYhgayu86QNuPVPFfAcn9PumAzVR8PizojhSEH9Ez8h9F8PwfaTMthrcd7YM/8AqTBuQTUnpMVVr/8ArM5/7nE/yb9UYsMvw4px1TB4ztWgMcNimYMtiQadLU7ptzSXlxkgBsGZkSJ4xaYCtMdIrE16RaeNCYkclmyhJYNJilQ7mJPI/fNeDYM3Ekj1pU04KS5odBoZ+XHx+YR+7GiRBEgmOIpMdUWIrtAIIkVkzPW/3wVMi2/6LR0hph0AxwEG3H4qrwaDcA7UFfT7PmqUhlBjyKojiefRP9y2D+kmlxIA6+SQ5kDnMfMRHh6rRSEFNOH6qGOE3/lQMcgRQhAHTJsdlWQqOlyHtZmcGGjFcR/uhwA5apXZdj+3tmZlgIcKPYK9S2fUHwXyoGV12Rw2PwO8ASyXAchqPkY8VEuOUGKZ9IwPabJvMDHa3/mHsHm4ALWymZwnz7vFY+3wljo8iYXw/FdUEahLZrueYG8EHzVvs3tHFwHF+G6HEQYg0MVgiItXZPtdk0k+j7mwtkkEDkII/hCwipDpC+M4vtRmnkf+UnoGjrMAVTf7rmHgh+LiEcNRA4QQCrWi6uyXOvD63j9oYbPjexv/ACLWnrUqlmfafLCnvi4inda5w/yAg+a+WSJWd2h2o4SxtNiRfoOHVWtKNW2TuSfCR9Mz3+oGWw3AD3j3fihoBaI4k1XM5/8A1FxS939PGEykFwDsQiBJdqJaKzAAsuBe+8nwG/UpZfKzcY+Gis6DtD2ifjGcR73k7OJDZN+4Dp9FTd2jBljdJPD9vFZbXKZTUUM6XLe12ZYABjYkcC8keTpRY/tlmnxqxHuji4x5CFzMpugwDYRclUoxXIqOgZ7WY9pP+T/O8AQqub7fxZoe9uTBj5ysN+JtYfPqmYbABLr3ApHj9EnKgxRdZjvxKvJdwmTvw6pgdBnTtcixm4kWmdjus5+eMAAaY4fdlD888gCSI+4WTtsqjWMEwS83uXGKbBsCd/sKq/HaHQWNME3mfEzJKzziE7mV5xM1TjGhUazM4yZDGtAO1T5lL/qD+c/4D6qppAbzJQ+CvFAOcOBE2l1LbeiW2QYuCCOB5n0PhxVh7GwTuDsByH1SqCBUxQE8eN7Hyr58qZZL2nqIFL3ixnYbIdRA1AcpbPS3kOUWRseBSKAWsfJSSDsR1cajxpM+hRYATIkVBA+GpFwaG/3wSg6KiviI3vz3qrLw0d6D/wDU1sTeK2CrvgERN7zNKja8JpgHrhwtFYtS4rFjIA/lTSlCJqRJoQCKKGgTMeFd72XjhNEU6TM2/ZFgJxsrNW2ioO33+iS7LwRPLiLq4Gx8O9+fLpfxheg/DQWuDMbX2vZPIDMdQ3stTs7tDR3S6AafseSU5rS2SADFRanGf4VF+GW3sbHYhVaaoKOlc8O0jhUHeQSeu5StBA4Xt8wqmSxCAyLyRO4BifvkFt5fCe8Aw4EkEzNREz1BhJWnRLX0z3A1I8RsR9Veymp8BsTFnap+XJauV7FDnAuM9R+syp9oe0mZbD04YbrfqaIjuRRzjzBIod1tFtLky/64RidoY7WNc3W3XSQ0k6TvJI9OiwXPFT8Rm5t1jfx8lWDvEoveEcknJs0jFIl07z4qJXnvlCCiyqD1ImCdwOZsibhQJcYpIBMef05JT8Un9AKDyRkFFpr9J7t+Yr1r8I6VScR0mAS48YueSVq2FfmV5x00mvEbchF0rChoIbep4bDrxKDEftsNr13PVJJhGHU++aVjoNwETNUDSiL+Aoo0etk2AbAINa/NealApjCiwosh8IfelK1KNSeQqNECp3gbEb8Cb7ILAnTYxAnjRLxXENniJBLRFJud7EKdbw4zDbQSaQbg78VzDCe4wC0TqGw32kblLGM3pIBkbiYJvIHETxVjBzLqNc4VNnkmBNwYKt6mWIECwa0AC/DZTlXgGczHbNOEi9hNbqZaRLTIJiR8r8B4qw5mo96CJmCGx0sibAnusbJ/C0DpW6MkMVlsPvTUiCRQbfwmY2CZoAJqR4D9/JNY6DK856WTsRVGWMVdvWABWDKl2XBiXE85rvw6p5dzSnlPJjAfgN69UDqw0AQKBG4K3kMqXG1k7AudlZY30iRxIjyW/lsJxIle7JykNstPCYAumEeDnm7ZbymWgcOi5T2g9k2gHEw3OLi55dMGjjIiRtXzXX4eLCYMQEQVbFF0fHT2eQfijw/dS7Jjd3ofqvoGc7GY55MXWRm+wyKtWTUl0aqaOV/o2c/OB/8AkqviDDEgF2oRUwRziBU+S18zhOYYIhVsRjXCHDxio6FZ5Ndl2Ufckt7pBBj1sJtKTLYvX+bJjsF7Kg0EmQfsqscSampPFUnYw/eQIFJvx/hQ1s1QyDyRtsqQAPXiSp0wTWUBckwCmOaY/EkAcEnUplFhQQTWFIBRgoAbK9IQSoTsDYw8UsEFxJg8NUTJ478IQPa0tbqpApIm1IEzT91Q98IkmXfXc1jwhLdiFxrtzosKCjSy2kgAgQD3ZI3Na7VilE4voSPJZrtQqKAjYfcn6qzlnxQSKb04z4WSaBol2aPBLGYebBWXlhBO03EfZSjEGZgc4HCeIuhV8AU7GdMF0KHY3MnxTzpMQSQLyAYv+HnqXsDLtNAJvEmpoIF9kJoCscydl5rnnirrMAD8MeS0MtlJ2Vqn0TZn5bKvPFdX2VkC1qDKZciIAC2cLDcBVwjkIVJBY7CYQ1J96nF4Aqs7FxRK3izCSL7cYJ7MZZTMZNbjKiUXn4h/hIfjcaRUzSg6pfvl44gIgiQbg1BQBXzWSa8SACDYiCD0Kwc5kC2kLo8rhsY3Sxoa2SYFhPDgl5loN1EoJlKVdHHOy54KnmOypq2h4G37LsXZQFDiZQaTTZQtJ3wytyj525paYKh3JdHmeyg4LEzGTc3ZXPRlH+jSOpGRW1lRqXiEMLIsIryGF5BQSOUsI5QSFKlBKmUAWGZNznlsgGT8W/3TzCjEwHtu09ZEfdlGVx+9JqSak8IM/fJaHbIOlkTFSZEWoK7084WXNgUGvJAEVitq8KcqqziYp0xBaTFTuBNweX3dA7KUBa4OAvNBbVPMR1R4rntuNTbgwSK2n78UygmvYQ0VIJEgdBvW33KVorQktmBaSOJF/qle/eDE1tHCQEzDeGtJ1d8zbbrVIB+Xc6JIoJAmgG3TwKYBFRqrNz5HiFUwsaRLWgRUzNdiJNDPPin4eYGmSAGmSBz+dwk0SPw8fXUnhJ4GnHjCsYeZ0bnkDXxoVljMHZ1LkWitjdHjPJ0maE704VSSrodHS5btYNEvFP8AbFBW9VsZbtJj2ggxXTBuD4bUuuIGO0MLTXV+kfROGPDGtFDWwmORG+/mnlJEuJ2Ls8yXNDhLYmtK7dVm4na7KwZi0b2t97Lln6myW1s7gIdI38fNFiEhhImt6jeaW5hXuSJ20dK3tdpDYBJdsNo5q5hZkOsfDcdVxuHiwARetKzWitMzBDXAEy4V3p918lS1WuxPSXh1TMbgUfvVzPZmaczVNWj7EStfBzrXCZFOJC0jqJmcoNGkMVEXSs9mMHVBB6FND1opWTRcACa0cVRZiprMVOxUMxMqw1ip3qqOZ7IYRX5lXDiISAjKX0Ko5PPdhie66BzE/JY2N2e9tdPlX0XfYuDO6yM3gQVzztcm0JeHGubC8ujGXbfS2egSMbs9jttP/GAstxG1mGAphX8bs0j4DI4G6pYuG5tHCFakn0IiF5QCplUB0v8AbWF0NbG5iCCDBsTq5eCz8XIPc7U1weA6IqLGYrM+a3c1h6xctJmHCCJgDTI41VLJloaWB5Ok1oRUwBPKnVcUJyrsSZhuxixxBbB4OBFzqqCSOA6AK+cYOZ7wsP5QZuaSAOMceBV5pDy5uI0PAMNJiTDZcZFfEJeN2c2HYbZDXEOBmWuid9jWOK0zV8oqzPzjS/SdIJdOl0gTFKncTQLODHAxaTHirmMNGhrx3mSTFZBMjkFoYDi8az3Q0xyId3b8Z+7K26CzILi0Fp3gXPnzS34kxSwj1vzWmez/AHrdTHEmPhMUNoptA+SzcxliwCSK8CmmmMHDEkC5JsFZeQKSDUVpIO9Rcc0GUaS6jZ2MfU0EpuJhF2pwBMEcfnxB28UwIMai6YFwJEjhfatkZxA6IvWsQDc+BmnkqZrypNZretVDamlLX40n6oA0MLFJiTG2wnrG0In47Y7woRFpJpFzaw8iq2AZcSdr/KBXhCTiuglsRsTM+Ufd0qA0MCC1xBi3n+iFhc10meGqQIFOdd0trhpoYBGk1NK0srOB32uaQBAibwetzUBICcZ4dIaQKTAPe2JoOX6prsuThzUS6DSSKCJHAx6IMqWtBDgHa7H8QiR107fyFYZiCrJBLbQCRA/PTgbxSKoaAqZbGfhvBcYaY5Tamm8/VdDg5trgTaIJm46i6zccMa465NorXVSpfFNzvbdFivcWODoaSIbEyADNOIDb8vMOMmuiJQTLmFm9TwAYB73eH+0d0Vod1dDlyeGHNcHuaQ0m5JFBAMzURSpgUHNdA3M9yTU0kN2kT8lrGf0iUPhebii0qh2rmnNDSxwBdQUNQKyIMcKb+iqMfJLS74uBIgyJE172mTxE05NzGbEabCABBMk8jffcfRKWpapgoUzTZm2hrZNx1oGyST0Hqq2dzDKDciaQYm3Lj5LMw9TQXSNFWuBiO8ahokmJMGu0UiD5gDHy0iCTYl08J/KZpsKnok5uSoagk7CB1VbHTwF9r/MKNXJNyzCQNXPa5kS48hZEMORINxI6LCUeeCm6EFwQ4jGuBabHgnPYQq7iQli0Kyq/stkQJB4zKr/2l3ELSbiKdfRPKQy1j4mjRYxMf7bcRMkbHiieA1xc0ESAXBugilQ7VcU+7peZwn6CQ2dUibGgpAt49VmMY/TEkDVFXCdhNYm1uXErNRT9EkW8zp1FzKuizjWXDYXmBWKQquawC5jS0ukAWkRcVABMTtdW34EsbVwgxqMd6ATB9bKvkm1Id0ZWASQKSBNOPNaR4RSMTG1BxDiSRQyZtz3C3cniMcxzQ4Aae8YII/CLggggxE3UPLXCHRM94EVHdiYFbcVDGBrXCGsNLyNwCN5oTx2VN2BGUYWSwEl2raAIFK8zP3ueYyzXtuBFbU26GDZIeT3iYkTYzMnruT92SMrmXGSZNfmd9vBNplDGkNfAhokSBMA/mI2pWivDGxA4EEaTGobtiaWt9fFV8YNcZki5tST8IjzPRefiRYiNVSSeE8L1SasB2ZwGPYXNY0OqKUmh2ApWfJYWEIdBEVqK0FLLXy5LTWSN3Q6JJNppx/lKx8iwgvBIJgxeOI4V5lNOuAKz8UNLXCSCK+B00NhZV8e80r53VjN5YtAOoFraGlZrM7bcUvBypcJiARIJNL7RbgqsAXYxDQGk1FR98VbyuZYxpDp1RFCQRO/A29VR904SIM7eZ8dldOb7oY6oFhW5njWPFADgx2GGYrX6ppBrAcbEW2PLzTMm8kS5wB1NkyJ5zxoTHGsL2TxNTC0hhbLfjBgC0zN6z4HkqryC4Bn5jUGgFRabbzwNUAW88Gte2sgHXqgEkDoYAtQR4Kzj50HDLgIfpEGAI11hoAgAmYtQwLFZmPiyC4NaW0mKDavdNTcb0d4izlcvrZp+FwDQ3SHEmTMkmGx3+MCTNwgC/ksYYmsPJk6dI5NjY3NjtbjVVszjkPHfERtEE6bkETufs1qYGKZdcubSQ6kTB2k/DcU9Iv8AaLCXNcGS5zYBfGkx+UzYUu0U6yk0BWzWPq2cCTpAginIk28bRfZ78KrRYwdmkGlhHOk9bJOl+gB7gRJkkyb/AIacALcknGzLYpXSRpIkGkxIi1+Nz4K7AJ2G1x0Eg1g8ZBtqjoY+Stl5YQCIIdcWECIgxPxRStN1lYWZGo8L1585mnHfxTn43eJ79G2cIF6H4rGvrVAGizMCpOw0toBSlKjmnZbHYHwABI6RWn63WYyal00Mk6QY2IncSU3LgudrqQYEuEUMUkbfzsjklqzYZjtcdI5+l0ONl5VDJZgyKAAkuFQT4kE0ormPjOLBF7Hyt8/JVf0hxp8Fd+XhL92fsq/lySK1XpZ+YeanEWTDfmWBpBIEDjXwC5vL5mHaSJ0uMSKgkx4VVfHxnHEmfQJ2SYCSY4n0WenpqKf6XFUaLswdTrBxqRApUkzSSZ3kgpT3a4MEkRInjEREz9+M55giIviMB5ilEDDAjg50cpc76DyVUMJo04heDIIuADpAMRJsaHwi6qZ98aHNoTYGsGu211bZcc59WFVu1rsG0Np4uVIobm2aWDV/1m1DpINDHd8/KhgaiTp34zUm4vXcqH1B8B6D6J3Z/ecJr3mj0KoCw4dwiTNJqeDdJNN+WyrlneoQWmJmwPQXIifFWm1Ywm50zwMkiotslA+O1a8eKAJzJLHNBJIFLtMmBqgA02p0TmO5cyaRFaXUY9GiKXHkFOJQDqPv1UsAg1p3BkgxUWg+JmPLZQHmCWiskAG1zYCtdJ8kLPijb91Lj08hzSAHEY46HsmRJjhYd0C9jyMhVDlySS43PAA96shtIrSLeCudpUOkUE2/yWZh1EmpJNd6qkJFl72+7aACDWTEtgzF7XPzCpRbcD7tujxLnoP0TWMECm8ehTGLx3TZsAEkC2kfFXjQ0V/s3G7zXAQ1gIvG1ASaVLnC1uJVbLNktP8AyHkxxTuyGA4gEbwgDTxnhrnNMyS14ggO7waAOUxBnYi1IqNc7uySf/GAKFxqa6SGgEQOPiboMywDGI/+RoqSTsbmt080c4CgJd/1oI4QALJNAJa8Oo4GNjYkbGOngVnYr9LjpMzIqBtuRzWpmW9wP/FoNeoYbW/EfNVsvhj3sQKMB8YuePikuAEYWUJADSHEkCJikcTteVqZph92XSSdLgALbzxqCCgwrxsXAnzmnDwS8PEOnEr8JkcobNPJJt2AeAPwubEgEkQSYDQZneN+PJWsxBkxUTERE2oTxt4LPwqeL3Tzqh94RQGB3fUtQ036IezEM6my5s2LY3mgrQX+63BjQ0Vgk0NY9eR9aqoKuPM4fq7D+qPF7skU/aPqfNUwaLrMw33cA1EilZI/cKl7t/2HfVHh79fnP0S/eHl5BAqP/9k=)

---

## Ancient Trajans Bridge

Marvel at the remnants of the ancient Trajans Bridge, a testament to the regions rich history. Built by the Romans, this engineering marvel once spanned the Danube, connecting the two banks. Today, the ruins provide a glimpse into the past.


---

##  River Cruises and Boat Tours

Experience the majesty of Đerdap from the water with a river cruise or boat tour. Sail through the narrow passages, witness the towering cliffs, and appreciate the geological wonders that have shaped this incredible landscape.

![River Cruise](https://static.wixstatic.com/media/b27ecd_a75435140d6f431f86c984ce51d111dc~mv2.jpg/v1/fill/w_560,h_372,al_c,q_80,usm_0.66_1.00_0.01,enc_auto/Brod-Djerdap_edited.jpg)

---

## Golubac Fortress

Perched on the banks of the Danube, Golubac Fortress is a medieval gem guarding the entrance to the Đerdap Gorge. Explore its towers, walls, and captivating views, and let the centuries-old stones whisper tales of battles and conquests.

![Golubac Fortress](https://www.serbianprivatetours.com/wp-content/uploads/2020/10/Golubac-fortress-featured.jpg)

---

##  Sunset Over Đerdap

As the day draws to a close, dont miss the opportunity to witness a Đerdap sunset. The play of colors on the cliffs and the reflection on the Danube create a breathtaking panorama, leaving an indelible mark on all who are fortunate enough to witness it.

![Đerdap Sunset](https://img.freepik.com/premium-photo/view-sunset-danube-gorge-djerdap-serbia_52137-41091.jpg)

---

# Conclusion

Our exploration of Đerdap concludes, leaving us with memories of rugged beauty, ancient history, and the timeless flow of the Danube. May this glimpse into the Iron Gates inspire you to embark on your own journey and discover the wonders that nature and history have woven together in this remarkable region. Until the next adventure, may your travels be filled with awe and discovery. Safe travels!',
'2024-01-15 14:49:21.232321+01',
4,
-5,
0,
'[]'
);

INSERT INTO blog."Comments"("Id", "UserId", "CreationDate", "Description", "LastEditDate", "BlogId")
VALUES
(-1, -7, '2024-01-15 14:49:21.074+01', 'Wow, what an incredible journey through Đerdap! The images of the gorge are absolutely mesmerizing, and your descriptions bring the region to life. I had no idea about the ancient Trajans Bridge, and the sunset over Đerdap looks like something out of a dream. The mix of history, nature, and adventure is truly captivating. This blog has definitely inspired me to add Đerdap to my travel bucket list. Cant wait to experience the Gates of Iron in person. Thanks for sharing this enchanting adventure!', '2024-01-15 14:49:21.074+01', -5),
(-2, -8, '2024-01-15 14:50:39.741+01', 'What an amazing virtual tour through Đerdap! The sunset over the gorge is a sight to behold, and I love how youve highlighted the cultural and historical aspects of the region. The Golubac Fortress seems like a must-visit, and the idea of a river cruise through the Iron Gates is now on the top of my travel wishlist. Your blog has ignited my wanderlust, and I cant wait to experience the magic of Đerdap firsthand. Thank you for sharing this incredible journey!', '2024-01-15 14:50:39.741+01', -5),
(-3, -8, '2024-01-15 14:51:12.237+01', 'This blog beautifully captures the essence of Đerdap! The images showcasing the rugged beauty of the gorge and the ancient Trajans Bridge are truly captivating. I appreciate the historical insights provided, making the journey through this natural wonder even more enriching.', '2024-01-15 14:51:12.237+01', -5),
(-4, -9, '2024-01-15 14:52:15.1+01', 'Palic looks like a hidden paradise! The images of the lake and park are absolutely stunning, and your vivid descriptions make me feel like Im already there. The mention of the Art Nouveau architecture adds a cultural touch to the experience. Im now seriously considering Palic for my next getaway. Thanks for bringing this enchanting destination to my attention!', '2024-01-15 14:52:15.1+01', -4),
(-5, -9, '2024-01-15 14:52:24.981+01', 'This blog on Palic is a breath of fresh air! The Grand Terrace overlooking the lake is now on my must-visit list. Your descriptions of the culinary delights and the cozy atmosphere make it sound like the perfect spot to unwind. The images of Palic Park are so inviting; I can almost feel the tranquility through the screen. Cant wait to experience the beauty of Palic in person!', '2024-01-15 14:52:24.981+01', -4),
(-6, -6, '2024-01-15 14:53:02.653+01', 'Palic seems like a serene escape from the hustle and bustle of everyday life. The sunset at Palic Lake looks magical, and the idea of exploring the Art Nouveau architecture adds a unique charm to the visit. Your blog has sparked my interest, and I can imagine myself leisurely strolling through the park or enjoying a meal at the Grand Terrace. Thanks for sharing the beauty of Palic with us!', '2024-01-15 14:53:02.653+01', -4),
(-7, -6, '2024-01-15 14:53:37.349+01', 'Kopaonik looks like a winter paradise! The images of the snow-covered slopes are breathtaking, and your detailed descriptions of skiing adventures have me itching to hit the slopes. The mention of the Winter Wellness experiences adds an extra layer of relaxation to the trip. Kopaonik is now on my winter travel bucket list!', '2024-01-15 14:53:37.349+01', -3),
(-8, -6, '2024-01-15 14:54:06.066+01', 'Your exploration of Fruska Gora has truly piqued my interest! The images of the lush landscapes and ancient monasteries evoke a sense of tranquility and history. I had no idea about the cultural richness and diversity that the region holds. Fruska Gora has now earned a spot on my travel wishlist. Thank you for showcasing the hidden treasures of this enchanting destination!', '2024-01-15 14:54:06.066+01', -2),
(-9, -6, '2024-01-15 14:55:18.951+01', 'Your exploration of Đerdap is nothing short of mesmerizing! The images of the Gates of Iron and the ancient Trajans Bridge are truly breathtaking. I appreciate the historical insights, and the idea of a river cruise through the gorge has me daydreaming about an unforgettable adventure. Your blog has not only highlighted the natural beauty of Đerdap but also provided a glimpse into its rich history. Im now eager to experience the magic of the Iron Gates myself. Thank you for this virtual journey!', '2024-01-15 14:55:18.951+01', -5),
(-10, -5, '2024-01-15 14:56:43.481+01', 'Your blog about Kopaonik has completely transported me to this snowy wonderland. The skiing adventures, the cozy après-ski scene at Grand Terrace, and the promise of rejuvenating in the thermal springs - it sounds like the perfect winter retreat. The images of the sunset over Kopaonik have me daydreaming about experiencing that magical moment in person. Thanks for sharing this winter adventure!', '2024-01-15 14:56:43.481+01', -3);