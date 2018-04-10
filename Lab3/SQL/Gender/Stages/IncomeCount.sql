CREATE VIEW public.stages_income AS
SELECT 
  date,
  Sum(income) * 10  AS income
FROM 
  events.stage_end,
  parameters.stage_end
WHERE 
  parameters_id = parameters.stage_end.id
GROUP BY
  date
ORDER BY
  date;