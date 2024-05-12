const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/api/Student",
    ],
    target: "https://localhost:7021",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
