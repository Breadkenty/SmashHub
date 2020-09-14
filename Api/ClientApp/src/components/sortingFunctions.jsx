export const sortingFunctions = {
  best: (a, b) => b.netVote - a.netVote,
  newest: (a, b) => new Date(b.datePosted) - new Date(a.datePosted),
  oldest: (a, b) => new Date(a.datePosted) - new Date(b.datePosted),
}
