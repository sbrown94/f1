<template>
    <div class="current-race">
        <h1 class="title">CONSTRUCTOR STANDINGS</h1>
        <div v-for="standing in standings">
            <h2>{{standing.Constructor.name}} - {{standing.points}}</h2>
        </div>
    </div>
</template>

<script>

export default {
  name: 'ConstructorStandings',
  data: function() {
      return {
          standings: ''
      }
  },
  created: function() {
      this.getRaceData();
  },
  methods: {
      getRaceData() {
          this.$http.get('http://localhost:52315/api/v1/Race/GetConstructorStandings').then(response => {
            this.assignStandingsData(response.body.MRData.StandingsTable.StandingsLists[0].ConstructorStandings);
          }, error => {
              // error
          });
      },
      assignStandingsData(data) {
          this.standings = data;
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
