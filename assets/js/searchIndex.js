
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"TfxExtensionShareSettings",
            content:"TfxExtensionShareSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension.Share/TfxExtensionShareSettings',
            title:"TfxExtensionShareSettings",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"TfxExtensionInstallRunner",
            content:"TfxExtensionInstallRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension.Install/TfxExtensionInstallRunner',
            title:"TfxExtensionInstallRunner",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"TfxExtensionPublishRunner",
            content:"TfxExtensionPublishRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension.Publish/TfxExtensionPublishRunner',
            title:"TfxExtensionPublishRunner",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"TfxExtensionShareRunner",
            content:"TfxExtensionShareRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension.Share/TfxExtensionShareRunner',
            title:"TfxExtensionShareRunner",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"TfxArgumentBuilder",
            content:"TfxArgumentBuilder",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx/TfxArgumentBuilder',
            title:"TfxArgumentBuilder",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"TfxServerSettings",
            content:"TfxServerSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx/TfxServerSettings',
            title:"TfxServerSettings",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"TfxTool",
            content:"TfxTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx/TfxTool_1',
            title:"TfxTool<TSettings>",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"TfxExtensionCreateRunner",
            content:"TfxExtensionCreateRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension.Create/TfxExtensionCreateRunner',
            title:"TfxExtensionCreateRunner",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"TfxSettings",
            content:"TfxSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx/TfxSettings',
            title:"TfxSettings",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"ITfxArgumentBuilder",
            content:"ITfxArgumentBuilder",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx/ITfxArgumentBuilder',
            title:"ITfxArgumentBuilder",
            description:""
        }
    );
    a(
        {
            id:10,
            title:"TfxExtensionPublishSettings",
            content:"TfxExtensionPublishSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension.Publish/TfxExtensionPublishSettings',
            title:"TfxExtensionPublishSettings",
            description:""
        }
    );
    a(
        {
            id:11,
            title:"TfxAuthType",
            content:"TfxAuthType",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx/TfxAuthType',
            title:"TfxAuthType",
            description:""
        }
    );
    a(
        {
            id:12,
            title:"TfxOutputType",
            content:"TfxOutputType",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx/TfxOutputType',
            title:"TfxOutputType",
            description:""
        }
    );
    a(
        {
            id:13,
            title:"TfxAliases",
            content:"TfxAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx/TfxAliases',
            title:"TfxAliases",
            description:""
        }
    );
    a(
        {
            id:14,
            title:"TfxExtensionCreateSettings",
            content:"TfxExtensionCreateSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension.Create/TfxExtensionCreateSettings',
            title:"TfxExtensionCreateSettings",
            description:""
        }
    );
    a(
        {
            id:15,
            title:"TfxExtensionInstallSettings",
            content:"TfxExtensionInstallSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension.Install/TfxExtensionInstallSettings',
            title:"TfxExtensionInstallSettings",
            description:""
        }
    );
    a(
        {
            id:16,
            title:"ICreatePublishSettings",
            content:"ICreatePublishSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Tfx/api/Cake.Tfx.Extension/ICreatePublishSettings',
            title:"ICreatePublishSettings",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
