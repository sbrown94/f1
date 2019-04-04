<template>
    <div class="current-race">
        <h1 class="title">NEXT RACE</h1>
        <h2 class="race-title">{{raceTitle}}</h2>
        <h2 class="circuit-name">{{circuitName}}</h2>
        <h2 class="until-start">{{timeToRace}}</h2>
        <div class="flag">
          <img v-bind:src="flagSource" />
        </div>
    </div>
</template>

<script>

export default {
  name: 'CurrentRace',
  data: function() {
      return {
          raceData: '',
          raceTitle: '',
          circuitName: '',
          timeToRace: '',
          flagSource: ''
      }
  },
  created: function() {
      this.getRaceData();
  },
  methods: {
      getRaceData() {
          this.$http.get('http://3.8.255.185/api/v1/Race/GetCurrentRace').then(response => {
            this.raceData = response.body.MRData;
            this.assignRaceData(response.body.MRData.RaceTable.Races[0]);
            console.log(this.raceData);
          }, error => {
              // error
          });
      },
      assignRaceData(data) {
          this.raceTitle = data.raceName;
          this.circuitName = data.Circuit.circuitName;
          var dateTime = data.date + " " + data.time;
          this.timeToRace = this.moment(dateTime, "YYYY-MM-DD hh:mm:ss").fromNow();
          this.flagSource = require('../assets/flags/' + data.Circuit.Location.country + '.svg');
          //this.flagSource = './assets/logo.png';
      }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.flag {
  width: 50%;
  margin: 0 auto;
}
</style>
