TRUNCATE TABLE "Characters"
, "Combos", "Comments", "ComboVotes", "CommentVotes", "Users" RESTART IDENTITY;

INSERT INTO "Users"
  ("DisplayName", "Email", "HashedPassword", "Admin")
VALUES
  ('Kento', 'kawakamikento@gmail.com', "AQAAAAEAACcQAAAAELnyllU/dSbBi8scfIUQXNJO/FI3DlnFtGoXYU34FakP8Bbnw0vjr0912+MzQuTvDg==", true);

INSERT INTO "Users"
  ("DisplayName", "Email", "HashedPassword", "Admin")
VALUES
  ('Kento726', 'kento@suncoast.io', "AQAAAAEAACcQAAAAEJCmn4+fAuaVlUG9spZf6U8jbGk0OWEz7mT1DRxj9Le0T3YxHJHBFmGpdElaPDQJYg==", false);


INSERT INTO "Combos"
  ("CharacterId", "DatePosted", "Title", "VideoId", "VideoStartTime", "VideoEndTime", "ComboInput", "TrueCombo", "Difficulty", "Damage", "Notes", "NetVote", "UserId")
VALUES
  ('14', '2020-07-21', 'Down Tilt Ground Float Nair', 'HO3gLgWx_i4', '115', '116', 'downTilt thenConditional forwardFlick thenConditional downMove andConditional holdConditional fullHop thenConditional neutralAerial', true, 'very hard', 26, 'This combo is best used against fast falling characters. Keep in
            mind, when doing the nair, you have to release the direction as soon
            as you get the momentum of going forward.', 43, 1);

INSERT INTO "Combos"
  ("CharacterId", "DatePosted", "Title", "VideoId", "VideoStartTime", "VideoEndTime", "ComboInput", "TrueCombo", "Difficulty", "Damage", "Notes", "NetVote", "UserId")
VALUES
  ('14', '2020-07-20', 'Down throw bair', 'HO3gLgWx_i4', '115', '116', 'grabBasic thenConditional downThrow thenConditional shortHop backAerial', true, 'easy', 13, 'This gombo is great', 22, 1);

INSERT INTO "Combos"
  ("CharacterId", "DatePosted", "Title", "VideoId", "VideoStartTime", "VideoEndTime", "ComboInput", "TrueCombo", "Difficulty", "Damage", "Notes", "NetVote", "UserId")
VALUES
  ('14', '2020-07-19', 'Dair float to fair', 'HO3gLgWx_i4', '116', '121', 'downAerial thenConditional holdConditional downMove andConditional fullHop thenConditional forwardMove thenConditional forwardAerial', true, 'medium', 21, 'This combo is awesome', 12, 1);

INSERT INTO "Combos"
  ("CharacterId", "DatePosted", "Title", "VideoId", "VideoStartTime", "VideoEndTime", "ComboInput", "TrueCombo", "Difficulty", "Damage", "Notes", "NetVote", "UserId")
VALUES
  ('14', '2020-07-12', 'Ground Float Nair', 'HO3gLgWx_i4', '0', '2', 'forwardFlick thenConditional holdConditional downMove andConditional fullHop thenConditional forwardFlick neutralAerial', true, 'hard', 8, 'This combo is phenomenal', 2, 1);


INSERT INTO "Combos"
  ("CharacterId", "DatePosted", "Title", "VideoId", "VideoStartTime", "VideoEndTime", "ComboInput", "TrueCombo", "Difficulty", "Damage", "Notes", "NetVote", "UserId")
VALUES
  ('8', '2020-06-21', 'Some Fox Combo 1', 'cLbQpJiufLs', '217', '220', 'downAerial thenConditional upSmash', true, 'medium', 25, 'This combo is outstanding', 41, 2);

INSERT INTO "Combos"
  ("CharacterId", "DatePosted", "Title", "VideoId", "VideoStartTime", "VideoEndTime", "ComboInput", "TrueCombo", "Difficulty", "Damage", "Notes", "NetVote", "UserId")
VALUES
  ('8', '2020-05-21', 'Some Fox Combo 2', 'cLbQpJiufLs', '109', '111', 'forwardFlick thenConditional jabBasic thenConditional startRepeatConditional upTilt endRepeatConditional endRepeatConditional endRepeatConditional', true, 'hard', 26, 'This Combo is wow!', 43, 2);


INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('1', '2020-07-22', 'Uhm this combo is great wow!', 45, 1);

INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('1', '2020-02-21', 'How did you figure this out!', 2, 1);
INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('1', '2020-05-22', 'Awesome!', 21, 2);

INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('5', '2020-07-22', 'Nice fox lol', 45, 2);
INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('5', '2020-02-21', 'cool', 2, 2);
INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('5', '2020-05-22', 'pls teach me fox ty', 21, 2);

INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('3', '2019-07-22', 'This is so hard', 45, 2);
INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('2', '2017-02-21', 'idgi this is great tho', 2, 2);
INSERT INTO "Comments"
  ("ComboId", "DatePosted", "Body", "NetVote", "UserId")
VALUES
  ('2', '2018-05-22', 'lol', 21, 2);


update "Users" set "Admin" = 'true' where "DisplayName" = "Moderator";

INSERT INTO "Infractions"
  ("UserId", "ModeratorId", "BanDuration", "Points", "Category", "Body", "DateInfracted")
VALUES
  (1, 8, 0, 1, 0, 'Spamming in the Peach Combo', '2020-09-01');

INSERT INTO "Infractions"
  ("UserId", "ModeratorId", "BanDuration", "Points", "Category", "Body", "DateInfracted")
VALUES
  (1, 8, 172800, 1, 0, 'Spamming again', '2020-09-01');

INSERT INTO "Infractions"
  ("UserId", "ModeratorId", "BanDuration", "Points", "Category", "Body" , "DateInfracted")
VALUES
  (2, 8, 0, 1, 1, 'Inappropriate posts', '2020-09-01');



INSERT INTO "Reports"
  ("UserId", "ReporterId", "ComboId", "Body", "DateReported", "Dismiss")
VALUES
  (1, 2, 3, 'This person is spamming', '2020-09-01', false);

  INSERT INTO "Reports"
  ("UserId", "ReporterId", "ComboId", "Body", "DateReported", "Dismiss")
VALUES
  (1, 2, 3, 'This person is spamming again', '2020-09-01', false);

  INSERT INTO "Reports"
  ("UserId", "ReporterId", "ComboId", "Body", "DateReported", "Dismiss")
VALUES
  (1, 2, 3, 'This person is spamming again and again', '2020-09-01', false);



  INSERT INTO "Reports"
  ("UserId", "ReporterId", "CommentId", "Body", "DateReported", "Dismiss")
VALUES
  (1, 2, 6, 'This person is spamming', '2020-09-01', false);

  INSERT INTO "Reports"
  ("UserId", "ReporterId", "CommentId", "Body", "DateReported", "Dismiss")
VALUES
  (1, 2, 7, 'This person is spamming again', '2020-09-01', false);

  INSERT INTO "Reports"
  ("UserId", "ReporterId", "CommentId", "Body", "DateReported", "Dismiss")
VALUES
  (1, 2, 5, 'This person is spamming again and again', '2020-09-01', false);



-- Admin:
-- update "Users" set "UserType" = 3 where "Id" = X ;

--Moderator:
-- update "Users" set "UserType" = 2 where "Id" = X ;
