CREATE VIEW public."StagesIncome" AS
SELECT 
  "Events"."StageEnd"."Date",
  Sum("Parameters"."StageEnd"."Income") * 10  AS "Income"
FROM 
  "Events"."StageEnd", 
  "Parameters"."StageEnd"
WHERE 
  "Events"."StageEnd"."ParametersId" = "Parameters"."StageEnd"."Id"
GROUP BY
  "Events"."StageEnd"."Date";