CREATE VIEW public.stages_win_count AS
SELECT 
  date,
  Count(*) * 10 as count
FROM 
  events.stage_end,
  parameters.stage_end
WHERE 
  parameters_id = parameters.stage_end.id AND
  parameters.stage_end.win = true
GROUP BY
  date;