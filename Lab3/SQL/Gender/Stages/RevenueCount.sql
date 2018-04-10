CREATE VIEW public.stages_revenue AS
SELECT 
  events.stage_end.date,
  Sum(currency_rate * income) as revenue
FROM 
  events.stage_end,
  parameters.stage_end,
  public.currency_rate
WHERE 
  parameters_id = parameters.stage_end.id
GROUP BY
  events.stage_end.date
ORDER BY
  events.stage_end.date;