CREATE VIEW public."StageStartCount" AS
SELECT 
  "Date",
  Count("StageStart"."Id") * 10 as "Count"
FROM 
  "Events"."StageStart"
GROUP BY
  "Date";
