
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"TfxSettings",
        content:"TfxSettings",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"TfxAliases",
        content:"TfxAliases",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"TfxAuthType",
        content:"TfxAuthType",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"TfxExtensionInstallRunner",
        content:"TfxExtensionInstallRunner",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"TfxExtensionPublishRunner",
        content:"TfxExtensionPublishRunner",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"TfxArgumentBuilder",
        content:"TfxArgumentBuilder",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"TfxExtensionInstallSettings",
        content:"TfxExtensionInstallSettings",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"TfxTool",
        content:"TfxTool",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"ICreatePublishSettings",
        content:"ICreatePublishSettings",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"TfxExtensionShareRunner",
        content:"TfxExtensionShareRunner",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"TfxExtensionShareSettings",
        content:"TfxExtensionShareSettings",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"ITfxArgumentBuilder",
        content:"ITfxArgumentBuilder",
        description:'',
        tags:''
    });

    a({
        id:12,
        title:"TfxServerSettings",
        content:"TfxServerSettings",
        description:'',
        tags:''
    });

    a({
        id:13,
        title:"TfxExtensionPublishSettings",
        content:"TfxExtensionPublishSettings",
        description:'',
        tags:''
    });

    a({
        id:14,
        title:"TfxOutputType",
        content:"TfxOutputType",
        description:'',
        tags:''
    });

    a({
        id:15,
        title:"TfxExtensionCreateSettings",
        content:"TfxExtensionCreateSettings",
        description:'',
        tags:''
    });

    a({
        id:16,
        title:"TfxExtensionCreateRunner",
        content:"TfxExtensionCreateRunner",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx/TfxSettings',
        title:"TfxSettings",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx/TfxAliases',
        title:"TfxAliases",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx/TfxAuthType',
        title:"TfxAuthType",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension.Install/TfxExtensionInstallRunner',
        title:"TfxExtensionInstallRunner",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension.Publish/TfxExtensionPublishRunner',
        title:"TfxExtensionPublishRunner",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx/TfxArgumentBuilder',
        title:"TfxArgumentBuilder",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension.Install/TfxExtensionInstallSettings',
        title:"TfxExtensionInstallSettings",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx/TfxTool_1',
        title:"TfxTool<TSettings>",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension/ICreatePublishSettings',
        title:"ICreatePublishSettings",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension.Share/TfxExtensionShareRunner',
        title:"TfxExtensionShareRunner",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension.Share/TfxExtensionShareSettings',
        title:"TfxExtensionShareSettings",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx/ITfxArgumentBuilder',
        title:"ITfxArgumentBuilder",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx/TfxServerSettings',
        title:"TfxServerSettings",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension.Publish/TfxExtensionPublishSettings',
        title:"TfxExtensionPublishSettings",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx/TfxOutputType',
        title:"TfxOutputType",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension.Create/TfxExtensionCreateSettings',
        title:"TfxExtensionCreateSettings",
        description:""
    });

    y({
        url:'/Cake.Tfx/Cake.Tfx/api/Cake.Tfx.Extension.Create/TfxExtensionCreateRunner',
        title:"TfxExtensionCreateRunner",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
