using LazyAbp.ReviewKit;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyAbp.ReviewKit.EntityFrameworkCore
{
    public static class ReviewKitDbContextModelCreatingExtensions
    {
        public static void ConfigureReviewKit(
            this ModelBuilder builder,
            Action<ReviewKitModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ReviewKitModelBuilderConfigurationOptions(
                ReviewKitDbProperties.DbTablePrefix,
                ReviewKitDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<Review>(b =>
            {
                b.ToTable(options.TablePrefix + "Reviews", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => new
                {
                    q.ModuleName,
                    q.SubjectId
                });

                b.HasIndex(q => q.ParentId);
                b.HasIndex(q => q.RootId);
                /* Configure more properties here */
            });


            builder.Entity<ReviewLike>(b =>
            {
                b.ToTable(options.TablePrefix + "ReviewLikes", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => new
                {
                    q.ReviewId,
                    q.UserId
                });
                /* Configure more properties here */
            });
        }
    }
}
