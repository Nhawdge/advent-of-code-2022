a.split("\n\n").map(x=>x.split("\n").reduce((a,c) => a + parseInt(c),0)).sort((a,b)=> b-a)
